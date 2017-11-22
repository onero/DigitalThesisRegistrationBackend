using System.Collections.Generic;
using DTRDAL.Context;
using DTRDAL.Entities;
using DTRDAL.Repositories;
using DTRDAL.Repositories.Implementations;
using DTRDALTests.implementations;
using Xunit;

namespace DTRDALTests.Implementations
{
    public class GroupRepositoryShould : IRepositoryTest
    {
        private readonly DTRContext _context;
        private readonly IGroupRepository _repository;

        public GroupRepositoryShould()
        {
            _context = TestContext.Context;
            _repository = new GroupRepository(_context);
        }

        private Group CreateMockGroup()
        {
            var group = new Group
            {
                Id = 1,
                Name = "D4FF",
                ContactEmail = "Test",
                StudentIds = new List<int> { 1}
            };
            _repository.Create(group);
            _context.SaveChanges();
            return group;
        }

        [Fact]
        public void CreateOne()
        {
            var createdEntity = CreateMockGroup();
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