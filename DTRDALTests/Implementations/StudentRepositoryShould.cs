using DTRDAL.Context;
using DTRDAL.Entities;
using DTRDAL.Repositories;
using DTRDAL.Repositories.Implementations;
using DTRDALTests.implementations;
using Xunit;

namespace DTRDALTests.Implementations
{
    public class StudentRepositoryShould: IRepositoryTest
    {
        private readonly DTRContext _context;
        private readonly StudentRepository _repository;

        public StudentRepositoryShould()
        {
            _context = TestContext.Context;
            _repository = new StudentRepository(_context);
        }

        private Student CreateMockStudent()
        {
            var entity = new Student {Id = 1, FirstName = "Test", LastName = "Test"};
            var createdEntity = _repository.Create(entity);
            _context.SaveChanges();
            return createdEntity;
        }

        [Fact]
        public void CreateOne()
        {
            var createdEntity = CreateMockStudent();
            Assert.NotNull(createdEntity);
        }

        [Fact]
        public void GetOneByExistingId()
        {
            throw new System.NotImplementedException();
        }

        [Fact]
        public void NotGetOneByNonExistingId()
        {
            throw new System.NotImplementedException();
        }

        [Fact]
        public void GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteByExistingId()
        {
            throw new System.NotImplementedException();
        }

        public void NotDeleteByNonExistingId()
        {
            throw new System.NotImplementedException();
        }
    }
}
