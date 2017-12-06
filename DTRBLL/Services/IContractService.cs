using DTRBLL.BusinessObjects;

namespace DTRBLL.Services
{
    public interface IContractService : IService<ContractBO>
    {
        /// <summary>
        /// Get a contract by primary ids
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="groupId"></param>
        /// <param name="companyId"></param>
        /// <returns>ContractBO, if ids exist</returns>
        ContractBO Get(int projectId, int groupId, int companyId);

        /// <summary>
        /// Get contract by groupId
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns>ContractBO, if id exist</returns>
        new ContractBO Get(int groupId);
    }
}