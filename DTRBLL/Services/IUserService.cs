using DTRBLL.BusinessObjects;
using DTRDAL.Entities;

namespace DTRBLL.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Create a new user in DB
        /// </summary>
        /// <param name="userBO"></param>
        /// <param name="userDBBO"></param>
        /// <returns></returns>
        User Create(UserBO userBO, UserDBBO userDBBO);
    }
}