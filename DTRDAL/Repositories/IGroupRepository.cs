using System.Collections.Generic;
using DTRDAL.Entities;

namespace DTRDAL.Repositories
{
    public interface IGroupRepository : IRespository<Group>
    {
        /// <summary>
        /// Get a group by its ContactEmail
        /// </summary>
        /// <param name="contactEmail"></param>
        /// <returns>Group if email exists</returns>
        Group Get(string contactEmail);
    }
}