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
            if (bo == null) return null;
            using (var unitOfWork = _uow)
            {
                var convertedProject = _converter.Convert(bo);
                var projectFromDB = _uow.ProjectRepository.Get(convertedProject.Id);
                if (projectFromDB == null) return null;

                if (convertedProject.AssignedSupervisorId != null)
                {
                    projectFromDB.AssignedSupervisorId = convertedProject.AssignedSupervisorId;
                }
                else
                {
                    projectFromDB.AssignedSupervisorId = null;
                }
                    
                
                if (convertedProject.WantedSupervisorId != null)
                    projectFromDB.WantedSupervisorId = convertedProject.WantedSupervisorId;

                if (convertedProject.Title != null)
                    projectFromDB.Title = convertedProject.Title;
                if (convertedProject.Description != null)
                    projectFromDB.Description = convertedProject.Description;
                
                if (convertedProject.Start != null)
                    projectFromDB.Start = convertedProject.Start;
                if (convertedProject.End != null)
                    projectFromDB.End = convertedProject.End;

                unitOfWork.Complete();
                return _converter.Convert(projectFromDB);
            }
        }
    }
}
