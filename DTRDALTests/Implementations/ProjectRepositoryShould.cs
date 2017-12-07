using System;
using System.Collections.Generic;
using System.Text;
using DTRDAL.Context;
using DTRDAL.Entities;
using DTRDAL.Repositories;
using DTRDAL.Repositories.Implementations;
using DTRDALTests.implementations;
using Xunit;

namespace DTRDALTests.Implementations
{
    public class ProjectRepositoryShould : IRepositoryTest
    {
        private readonly DTRContext _context;
        private readonly ProjectRepository _repository;

        public ProjectRepositoryShould()
        {
            _context = TestContext.Context;
            _repository = new ProjectRepository(_context);
        }

        private Project CreateMockProject()
        {
            var entity = new Project() {Id = 1,
                Description = "Test", End = DateTime.Now.AddDays(1),
                Start = DateTime.Now, Title = "Test",
                WantedSupervisorId = 1, AssignedSupervisorId = 1};
            var createdEntity = _repository.Create(entity);
            _context.SaveChanges();
            return createdEntity;
        }

        [Fact]
        public void CreateOne()
        {
            var createdEntity = CreateMockProject();
            Assert.NotNull(createdEntity);
        }

        [Fact]
        public void GetOneByExistingId()
        {
            var createdEntity = CreateMockProject();
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
            CreateMockProject();
            var entities = _repository.GetAll();
            Assert.NotNull(entities);
            Assert.NotEmpty(entities);
        }

        [Fact]
        public void GetAllWithAssignedSupervisor()
        {
            CreateMockProject();
            var entities = _repository.GetAllWithAssignedSupervisor();
            Assert.NotNull(entities);
            Assert.NotEmpty(entities);
        }

        public void DeleteByExistingId()
        {
            throw new NotImplementedException();
        }

        public void NotDeleteByNonExistingId()
        {
            throw new NotImplementedException();
        }
    }
}
