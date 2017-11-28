using DTRDAL.Entities;

namespace DTRDAL.Repositories
{
    public interface IContractRepository : IRespository<Contract>
    {
        Contract Get(int projectId, int groupId, int companyId);
    }
}