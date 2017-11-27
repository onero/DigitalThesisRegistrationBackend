using DTRBLL.BusinessObjects;

namespace DTRBLL.Services
{
    public interface IContractService : IService<ContractBO>
    {
        ContractBO Get(int projectId, int groupId, int companyId);
    }
}