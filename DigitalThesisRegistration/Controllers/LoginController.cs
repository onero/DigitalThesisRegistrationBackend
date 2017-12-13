using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using DigitalThesisRegistration.Helpers;
using DTRBLL.BusinessObjects;
using DTRBLL.Services;
using DTRDAL.Entities;
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
        [HttpPost("{create}", Name = "CreateUser")]
        public IActionResult CreateUser([FromBody] UserBO user)
        {
            UserHelper.CreatePasswordHash(user.Password, out var passwordHash, out var passwordSalt);

            var newUserDB = new UserDBBO
            {
                PasswordHash = passwordHash,
                Salt = passwordSalt
            };
            var userCreated = _userService.Create(user, newUserDB);
            if (userCreated != null)
            {
                return new OkObjectResult(userCreated);
            }
            return new BadRequestObjectResult(userCreated);
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Authorized token upon successful login</returns>
        [HttpPost]
        public IActionResult Login([FromBody] UserBO user)
        {
            if (user == null) return new BadRequestObjectResult(ErrorMessages.InvalidEntityString);
            if (!ModelState.IsValid) return new BadRequestObjectResult(ModelState);
            var userFromDB = _userService.Get(user.Username);
            if (userFromDB.userBo == null) return new NotFoundObjectResult(ErrorMessages.NotFoundString);
            user.Role = userFromDB.userBo.Role;
            switch (userFromDB.userBo.Role)
            {
                case Roles.Supervisor:
                    return HandleSupervisorLogin(user, userFromDB.userDbbo);
                case Roles.Administrator:
                    return HandleAdminLogin(user, userFromDB.userDbbo);
                case Roles.Group:
                    var group = _groupService.Get(user.Username);
                    if (group == null) return Unauthorized();
                    return HandleGroupLogin(user, userFromDB.userDbbo, group);
            }
            // YOU SHALL NOT PASS, because we don't know you :)
            return Unauthorized();
        }


        /// <summary>
        /// Verify group password
        /// </summary>
        /// <param name="user"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        private IActionResult HandleGroupLogin(UserBO user, UserDBBO security, GroupBO group)
        {
            if (UserHelper.VerifyPasswordHash(user.Password, security.PasswordHash, security.Salt))
                // If the group password checks out, resond with new JSON object
                return Ok(new
                {
                    token = GenerateToken(user),
                    role = Roles.Group,
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
        private IActionResult HandleSupervisorLogin(UserBO user, UserDBBO security)
        {
            if (UserHelper.VerifyPasswordHash(user.Password, security.PasswordHash, security.Salt))
                return Ok(new
                {
                    token = GenerateToken(user),
                    role = Roles.Supervisor
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
                new Claim(ClaimTypes.Name, user.Role)
            };

            switch (user.Role)
            {
                case Roles.Supervisor:
                    claims.Add(new Claim(ClaimTypes.Role, Roles.Supervisor));
                    break;
                case Roles.Administrator:
                    claims.Add(new Claim(ClaimTypes.Role, Roles.Administrator));
                    break;
                default:
                    claims.Add(new Claim(ClaimTypes.Role, Roles.Group));
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
        private IActionResult HandleAdminLogin(UserBO user, UserDBBO security)
        {
            if (UserHelper.VerifyPasswordHash(user.Password, security.PasswordHash, security.Salt))
                return Ok(new
                {
                    token = GenerateToken(user),
                    role = Roles.Administrator
                });
            return Unauthorized();
        }
    }
}