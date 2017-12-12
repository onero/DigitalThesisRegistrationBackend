using DTRDAL.Entities;

namespace DTRDAL.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Creates a new user in the DB
        /// </summary>
        /// <param name="ent">user to create</param>
        /// <returns>Created user</returns>
        User Create(User ent);
        User Get(string username);
    }
}