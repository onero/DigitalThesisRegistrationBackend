using System.Collections.Generic;
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
            throw new System.NotImplementedException();
        }

        public IList<StudentBO> GetAll()
        {
            throw new System.NotImplementedException();
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