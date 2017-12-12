using DTRBLL.BusinessObjects;
using DTRDAL.Entities;

namespace DTRBLL.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Create a new user in DB
        /// </summary>
        /// <param name="userBO">User input with username to create</param>
        /// <param name="userDBBO">UserDB input with passwordHash and Salt</param>
        /// <returns>Created user</returns>
        /// <remarks>If User role is "Group" the new group is created</remarks>
        User Create(UserBO userBO, UserDBBO userDBBO);

        (UserBO userBo, UserDBBO userDbbo) Get(string username);
    }
}