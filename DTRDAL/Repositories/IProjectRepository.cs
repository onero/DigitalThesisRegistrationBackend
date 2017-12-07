using System.Collections.Generic;
using DTRDAL.Entities;

namespace DTRDAL.Repositories
{
    public interface IProjectRepository : IRespository<Project>
    {
        /// <summary>
        /// GET all projects with an assigned Supervisor
        /// </summary>
        /// <returns>all projects with an assigned Supervisor</returns>
        IEnumerable<Project> GetAllWithAssignedSupervisor();
    }
}