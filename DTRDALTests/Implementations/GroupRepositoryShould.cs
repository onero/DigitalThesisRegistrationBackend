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
                Students = new List<Student> { new Student()}
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
            var createdEntity = CreateMockGroup();
            var entity = _repository.Get(createdEntity.Id);
            Assert.NotNull(entity);
            Assert.NotNull(entity.Students);
            Assert.NotEmpty(entity.Students);
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
            CreateMockGroup();
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