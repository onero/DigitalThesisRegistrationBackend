using DTRDAL.Context;
using DTRDAL.Entities;
using DTRDAL.Repositories;
using DTRDAL.Repositories.Implementations;
using DTRDALTests.implementations;
using Xunit;

namespace DTRDALTests.Implementations
{
    public class ContractRepositoryShould : IRepositoryTest
    {
        private readonly DTRContext _context;
        private readonly IContractRepository _repository;

        public ContractRepositoryShould()
        {
            _context = TestContext.Context;
            _repository = new ContractRepository(_context);
        }

        private Contract createMockContract()
        {
            var entity = new Contract
            {
                GroupId = 1,
                CompanyId = 1,
                ProjectId = 1,
                IsApproved = true
            };
            _repository.Create(entity);
            _context.SaveChanges();
            return entity;
        } 

        [Fact]
        public void CreateOne()
        {
            var createdEntity = createMockContract();
            Assert.NotNull(createdEntity);
        }
        [Fact]
        public void GetOneByExistingId()
        {
            var createdEntity = createMockContract();
            var entityToGet = _repository.Get(createdEntity.ProjectId, createdEntity.GroupId, createdEntity.CompanyId);
            Assert.NotNull(entityToGet);
        }
        [Fact]
        public void NotGetOneByNonExistingId()
        {
            var entityToGet = _repository.Get(0, 0, 0);
            Assert.Null(entityToGet);
        }
        [Fact]
        public void GetAll()
        {
            createMockContract();
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