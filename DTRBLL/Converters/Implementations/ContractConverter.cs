using DTRBLL.BusinessObjects;
using DTRDAL.Entities;

namespace DTRBLL.Converters.Implementations
{
    public class ContractConverter : IConverter<Contract, ContractBO>
    {
        public Contract Convert(ContractBO bo)
        {
            if (bo == null) return null;
            return new Contract
            {
                CompanyId = bo.CompanyId,
                GroupId = bo.GroupId,
                ProjectId = bo.ProjectId,
                SupervisorApproved = bo.SupervisorApproved,
                AdminApproved = bo.AdminApproved
            };
        }

        public ContractBO Convert(Contract entity)
        {
            if (entity == null) return null;
            return new ContractBO
            {
                CompanyId = entity.CompanyId,
                GroupId = entity.GroupId,
                ProjectId = entity.ProjectId,
                SupervisorApproved = entity.SupervisorApproved,
                AdminApproved = entity.AdminApproved
            };
        }
    }
}