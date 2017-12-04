using DTRDAL.Entities;

namespace DTRDAL.Repositories
{
    public interface IContractRepository : IRespository<Contract>
    {
        /// <summary>
        /// Get a contract by it's combined ids
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="groupId"></param>
        /// <param name="companyId"></param>
        /// <returns>Contract, if ids exist</returns>
        Contract Get(int projectId, int groupId, int companyId);

        /// <summary>
        /// Get a contract by its groupId
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns>Contract, if id exist</returns>
        new Contract Get(int groupId);
    }
}