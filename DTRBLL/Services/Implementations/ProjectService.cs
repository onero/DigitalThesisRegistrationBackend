using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTRBLL.BusinessObjects;
using DTRBLL.Converters.Implementations;
using DTRDAL.UOW;

namespace DTRBLL.Services.Implementations
{
    class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _uow;
        private readonly ProjectConverter _converter;

        public ProjectService(IUnitOfWork uow)
        {
            _uow = uow;
            _converter = new ProjectConverter();
        }

        public ProjectBO Create(ProjectBO bo)
        {
            using (var unitOfWork = _uow)
            {
                var convertedEntity = _converter.Convert(bo);
                var createdEntity = unitOfWork.ProjectRepository.Create(convertedEntity);
                unitOfWork.Complete();
                return _converter.Convert(createdEntity);
            }
        }

        public ProjectBO Get(int id)
        {
            using (var unitOfWork = _uow)
            {
                return _converter.Convert(unitOfWork.ProjectRepository.Get(id));
            }
        }

        public IList<ProjectBO> GetAll()
        {
            using (var unitOfWork = _uow)
            {
                return unitOfWork.ProjectRepository.GetAll().Select(_converter.Convert).ToList();
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ProjectBO Update(ProjectBO bo)
        {
            throw new NotImplementedException();
        }
    }
}
