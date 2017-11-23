using System.Collections.Generic;
using System.Linq;
using DTRBLL.BusinessObjects;
using DTRBLL.Converters.Implementations;
using DTRDAL.UOW;

namespace DTRBLL.Services.Implementations
{
    internal class StudentService : IStudentService
    {
        private readonly IUnitOfWork _uow;
        private readonly StudentConverter _converter;

        public StudentService(IUnitOfWork uow)
        {
            _uow = uow;
            _converter = new StudentConverter();
        }
        public StudentBO Create(StudentBO bo)
        {
            using (var unitOfWork = _uow)
            {
                var convertedEntity = _converter.Convert(bo);
                var createdEntity = unitOfWork.StudentRepository.Create(convertedEntity);
                unitOfWork.Complete();
                return _converter.Convert(createdEntity);
            }
        }

        public StudentBO Get(int id)
        {
            using (var unitOfWork = _uow)
            {
                return _converter.Convert(unitOfWork.StudentRepository.Get(id));
            }
        }

        public IList<StudentBO> GetAll()
        {
            using (var unitOfWork = _uow)
            {
                return unitOfWork.StudentRepository.GetAll()
                    .Select(_converter.Convert)
                    .ToList();
            }
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public StudentBO Update(StudentBO bo)
        {
            throw new System.NotImplementedException();
        }
    }
}