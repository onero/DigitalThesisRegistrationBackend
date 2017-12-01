using DTRDAL.Context;
using DTRDAL.Entities;
using DTRDAL.Repositories.Implementations;
using DTRDALTests.implementations;
using Xunit;

namespace DTRDALTests.Implementations
{
    public class SupervisorRepositoryShould : IRepositoryTest
    {
        private readonly DTRContext _context;
        private readonly SupervisorRepository _repository;

        public SupervisorRepositoryShould()
        {
            _context = TestContext.Context;
            _repository = new SupervisorRepository(_context);
        }

        private Supervisor CreateMockSupervisor()
        {
            var entity = new Supervisor { Id = 1, FirstName = "Test", LastName = "Test" };
            var createdEntity = _repository.Create(entity);
            _context.SaveChanges();
            return createdEntity;
        }

        [Fact]
        public void CreateOne()
        {
            var createdEntity = CreateMockSupervisor();
            Assert.NotNull(createdEntity);
        }

        [Fact]
        public void GetOneByExistingId()
        {
            var createdEntity = CreateMockSupervisor();
            var entity = _repository.Get(createdEntity.Id);
            Assert.NotNull(entity);
        }

        [Fact]
        public void NotGetOneByNonExistingId()
        {
            var entity = _repository.Get(0);
            Assert.Null(entity);
        }

        [Fact]
        public void GetAll()
        {
            CreateMockSupervisor();
            var entities = _repository.GetAll();
            Assert.NotNull(entities);
            Assert.NotEmpty(entities);
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