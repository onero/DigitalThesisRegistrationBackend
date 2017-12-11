using DTRBLL.BusinessObjects;

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
        bool Create(UserBO userBO, UserDBBO userDBBO);
    }
}