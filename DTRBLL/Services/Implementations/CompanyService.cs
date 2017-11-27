using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTRBLL.BusinessObjects;
using DTRBLL.Converters.Implementations;
using DTRDAL.UOW;

namespace DTRBLL.Services.Implementations
{
    class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _uow;
        private readonly CompanyConverter _converter;

        public CompanyService(IUnitOfWork uow)
        {
            _uow = uow;
            _converter = new CompanyConverter();
        }

        public CompanyBO Create(CompanyBO bo)
        {
            using (var unitOfWork = _uow)
            {
                var convertedEntity = _converter.Convert(bo);
                var createdEntity = unitOfWork.CompanyRepository.Create(convertedEntity);
                unitOfWork.Complete();
                return _converter.Convert(createdEntity);
            }
        }

        public CompanyBO Get(int id)
        {
            using (var unitOfWork = _uow)
            {
                return _converter.Convert(unitOfWork.CompanyRepository.Get(id));
            }
        }

        public IList<CompanyBO> GetAll()
        {
            using (var unitOfWork = _uow)
            {
                return unitOfWork.CompanyRepository.GetAll().Select(_converter.Convert).ToList();
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CompanyBO Update(CompanyBO bo)
        {
            throw new NotImplementedException();
        }
    }
}
