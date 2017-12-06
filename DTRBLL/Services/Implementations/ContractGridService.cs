using System.Collections.Generic;
using DTRBLL.BusinessObjects;
using DTRBLL.Converters.Implementations;
using DTRDAL.UOW;

namespace DTRBLL.Services.Implementations
{
    public class ContractGridService : IContractGridService
    {
        private readonly IUnitOfWork _uow;
        private readonly ContractConverter _contractConverter;
        private readonly ProjectConverter _projectConverter;
        private readonly CompanyConverter _companyConverter;
        private readonly SupervisorConverter _supervisorConverter;

        public ContractGridService(IUnitOfWork uow)
        {
            _uow = uow;
            _contractConverter = new ContractConverter();
            _projectConverter = new ProjectConverter();
            _companyConverter = new CompanyConverter();
            _supervisorConverter = new SupervisorConverter();
        }

        public List<ContractGridBO> GetAll()
        {
            var contractGridBOs = new List<ContractGridBO>();
            using (var unitOfWork = _uow)
            {
                var contracts = unitOfWork.ContractRepository.GetAll();
                foreach (var contract in contracts)
                {
                    var project = _projectConverter.Convert(unitOfWork.ProjectRepository.Get(contract.ProjectId));

                    var newContractGridBO = new ContractGridBO
                    {
                        Contract = _contractConverter.Convert(contract),
                        Project = project,
                        Company = _companyConverter.Convert(unitOfWork.CompanyRepository.Get(contract.CompanyId))
                    };

                    if (project.WantedSupervisorId != null)
                    {
                        newContractGridBO.WantedSupervisor = _supervisorConverter.Convert(unitOfWork.SupervisorRepository.Get((int)project.WantedSupervisorId));
                    }
                    if (project.AssignedSupervisorId != null)
                    {
                        newContractGridBO.AssignedSupervisor = _supervisorConverter.Convert(unitOfWork.SupervisorRepository.Get((int)project.AssignedSupervisorId));
                    }
                    contractGridBOs.Add(newContractGridBO);
                }
                unitOfWork.Complete();
                return contractGridBOs;
            }
        }
    }
}