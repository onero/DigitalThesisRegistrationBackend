using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using DigitalThesisRegistration.Helpers;
using DTRBLL.BusinessObjects;
using DTRBLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DigitalThesisRegistration.Controllers
{
    [Produces("application/json")]
    [Route("Login")]
    public class LoginController : Controller
    {
        private readonly IGroupService _groupService;
        private readonly IUserService _userService;

        private const string Group = "Group";
        private const string GroupPassword = "1234";
        private const string Supervisor = "Supervisor";
        private const string SupervisorPassword = "supervisorSecret";
        private const string Administrator = "Administrator";
        private const string AdminPassword = "adminSecret";

        public LoginController(IGroupService groupService, IUserService userService)
        {
            _groupService = groupService;
            _userService = userService;
        }

        /// <summary>
        /// POST new user
        /// </summary>
        /// <param name="user">User to create</param>
        /// <returns>Boolean for success</returns>
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserBO user)
        {
            byte[] passwordHash;
            byte[] passwordSalt;
            UserHelper.CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);
            
             var newUserDB = new UserDBBO{
             PasswordHash = passwordHash,
             Salt = passwordSalt
             };
             var userCreated = _userService.Create(user, newUserDB);
            if (userCreated)
            {
                return new OkObjectResult(userCreated);
            }
            return new BadRequestObjectResult(userCreated);
        }

        /// <summary>
        ///     Login
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Authorized token upon successful login</returns>
        [HttpGet]
        public IActionResult Login([FromBody] UserBO user)
        {
            if (user == null) return new BadRequestObjectResult(ErrorMessages.InvalidEntityString);
            if (!ModelState.IsValid) return new BadRequestObjectResult(ModelState);
            switch (user.Username)
            {
                case Supervisor:
                    return HandleSupervisorLogin(user);
                case Administrator:
                    return HandleAdminLogin(user);
                // If not Supervisor or Admin, only groups can login
                default:
                    var group = _groupService.Get(user.Username);
                    if (group == null) return Unauthorized();
                    return HandleGroupLogin(user, group);
            }
        }


        /// <summary>
        /// Verify group password
        /// </summary>
        /// <param name="user"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        private IActionResult HandleGroupLogin(UserBO user, GroupBO group)
        {
            if (VerifyPasswordHash(user.Password, user.PasswordHash, user.PasswordSalt))
                // If the group password checks out, resond with new JSON object
                return Ok(new
                {
                    token = GenerateToken(user),
                    role = Group,
                    group
                });
            // Else YOU SHALL NOT PASS!
            return Unauthorized();
        }

        /// <summary>
        /// Verify supervisor password
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private IActionResult HandleSupervisorLogin(UserBO user)
        {
            /*
             * UserBO:
             * Username
             * Password
             * 
             * UserDBBO:
             * PasswordHash
             * Salt
             * 
             * User:
             * Id
             * Username
             * PasswordHash
             * Salt
             * IsAdmin
             * */
            // UserDBBO userFromDB = _service.FindUser(Predicate<Query>);
            if (VerifyPasswordHash(user.Password, userFromDB.PasswordHash, userFromDB.PasswordSalt))
                return Ok(new
                {
                    token = GenerateToken(user),
                    role = Supervisor
                });

            return Unauthorized();
        }

        /// <summary>
        /// Generate login token for authorized user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Token as string</returns>
        private string GenerateToken(UserBO user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            switch (user.Username)
            {
                case Supervisor:
                    claims.Add(new Claim(ClaimTypes.Role, Supervisor));
                    break;
                case Administrator:
                    claims.Add(new Claim(ClaimTypes.Role, Administrator));
                    break;
                default:
                    claims.Add(new Claim(ClaimTypes.Role, Group));
                    break;
            }

            var token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(
                    JwtSecurityKey.Key,
                    SecurityAlgorithms.HmacSha256)),
                new JwtPayload(null, // issuer - not needed (ValidateIssuer = false)
                    null, // audience - not needed (ValidateAudience = false)
                    claims.ToArray(),
                    DateTime.Now, // notBefore
                    DateTime.Now.AddDays(1))); // expires

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        /// <summary>
        /// Verify admin password
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private IActionResult HandleAdminLogin(UserBO user)
        {
            if (UserHelper.VerifyPasswordHash(user.Password, user.PasswordHash, user.PasswordSalt))
                return Ok(new
                {
                    token = GenerateToken(user),
                    role = Administrator
                });
            return Unauthorized();
        }
    }
}