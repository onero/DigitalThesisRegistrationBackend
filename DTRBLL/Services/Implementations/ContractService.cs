using System.Collections.Generic;
using System.Linq;
using DTRBLL.BusinessObjects;
using DTRBLL.Converters.Implementations;
using DTRDAL.UOW;

namespace DTRBLL.Services.Implementations
{
    internal class ContractService : IContractService
    {
        private readonly IUnitOfWork _uow;
        private readonly ContractConverter _converter;

        public ContractService(IUnitOfWork uow)
        {
            _uow = uow;
            _converter = new ContractConverter();
        }

        public ContractBO Create(ContractBO bo)
        {
            using (var unitOfWork = _uow)
            {
                var convertedEntity = _converter.Convert(bo);
                var createdEntity = unitOfWork.ContractRepository.Create(convertedEntity);
                unitOfWork.Complete();
                return _converter.Convert(createdEntity);
            }
        }

        public ContractBO Get(int groupId)
        {
            using (var unitOfWork = _uow)
            {
                var resultFromDB = unitOfWork.ContractRepository.Get(groupId);
                return resultFromDB == null ? 
                    null : 
                    _converter.Convert(resultFromDB);
            }
        }

        public ContractBO Get(int projectId, int groupId, int companyId)
        {
            using (var unitOfWork = _uow)
            {
                var result = unitOfWork.ContractRepository.Get(projectId, groupId, companyId);
                return _converter.Convert(result);
            }
        }

        public IList<ContractBO> GetAll()
        {
            using (var unitOfWork = _uow)
            {
                return unitOfWork.ContractRepository.GetAll()
                    .Select(_converter.Convert)
                    .ToList();
            }
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public ContractBO Update(ContractBO bo)
        {
            throw new System.NotImplementedException();
        }
    }
}