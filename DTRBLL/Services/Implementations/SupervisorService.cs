using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTRBLL.BusinessObjects;
using DTRBLL.Converters.Implementations;
using DTRDAL.UOW;

namespace DTRBLL.Services.Implementations
{
    internal class SupervisorService : ISupervisorService
    {
        private readonly IUnitOfWork _uow;
        private readonly SupervisorConverter _converter;

        public SupervisorService(IUnitOfWork uow)
        {
            _uow = uow;
            _converter = new SupervisorConverter();
        }
        public SupervisorBO Create(SupervisorBO bo)
        {
            using (var unitOfWork = _uow)
            {
                var convertedEntity = _converter.Convert(bo);
                var createdEntity = unitOfWork.SupervisorRepository.Create(convertedEntity);
                unitOfWork.Complete();
                return _converter.Convert(createdEntity);
            }
        }

        public SupervisorBO Get(int id)
        {
            using (var unitOfWork = _uow)
            {
                return _converter.Convert(unitOfWork.SupervisorRepository.Get(id));
            }
        }

        public IList<SupervisorBO> GetAll()
        {
            using (var unitOfWork = _uow)
            {
                return unitOfWork.SupervisorRepository.GetAll().Select(_converter.Convert).ToList();
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public SupervisorBO Update(SupervisorBO bo)
        {
            throw new NotImplementedException();
        }
    }
}
