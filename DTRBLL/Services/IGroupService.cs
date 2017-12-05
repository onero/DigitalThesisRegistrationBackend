using DTRBLL.BusinessObjects;

namespace DTRBLL.Services
{
    public interface IGroupService : IService<GroupBO>
    {
        /// <summary>
        /// Get a group by its ContactEmail
        /// </summary>
        /// <param name="contactEmail"></param>
        /// <returns>GroupBO if email exists</returns>
        GroupBO Get(string contactEmail);
    }
}