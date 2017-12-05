using System;
using System.Collections.Generic;
using DTRBLL.BusinessObjects;
using DTRBLL.Services;
using DTRBLL.Services.Implementations;
using DTRDAL.Entities;
using DTRDAL.Repositories;
using DTRDAL.UOW;
using Moq;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using Xunit;

namespace DTRBLLTests.Implementations.Services
{
    public class ProjectServiceShould : IServiceTest
    {
        private readonly Mock<IUnitOfWork> _uow = new Mock<IUnitOfWork>();
        private readonly Mock<IProjectRepository> _repo = new Mock<IProjectRepository>();
        private readonly IProjectService _service;

        public ProjectServiceShould()
        {
            _uow.SetupGet(r => r.ProjectRepository).Returns(_repo.Object);
            _service = new ProjectService(_uow.Object);
        }

        [Fact]
        public void CreateOne()
        {
            _repo.Setup(r => r.Create(It.IsAny<Project>())).Returns(new Project());

            var entity = _service.Create(new ProjectBO());

            Assert.NotNull(entity);
        }

        [Fact]
        public void GetOneByExistingId()
        {
            _repo.Setup(r => r.Get(It.IsAny<int>())).Returns(new Project());

            var entity = _service.Get(1);

            Assert.NotNull(entity);
        }

        [Fact]
        public void NotGetOneByNonExistingId()
        {
            var entity = _service.Get(0);
            Assert.Null(entity);
        }

        [Fact]
        public void GetAll()
        {
            _repo.Setup(r => r.GetAll()).Returns(new List<Project> { new Project() });

            var entities = _service.GetAll();

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
        
        [Fact]
        public void UpdateByExistingId()
        {
            _repo.Setup(r => r.Get(It.IsAny<int>())).Returns(new Project{Id = 1});
            var projectFromDB = _service.Get(1);
            var updatedProject = new ProjectBO
            {
                Id = projectFromDB.Id,
                Title = "Test",
                AssignedSupervisorId = 1,
                Description = "Test",
                WantedSupervisorId = 1,
                Start = new DateTime(2017, 1, 1, 1, 1, 1),
                End = new DateTime(2017, 1, 1, 1, 1, 1)
            };
            var result = _service.Update(updatedProject);
            Assert.NotNull(result);
            Assert.Contains(updatedProject.Title, result.Title);
            Assert.Contains(updatedProject.Description, result.Description);
            Assert.Equal(updatedProject.AssignedSupervisorId, result.AssignedSupervisorId);
            Assert.Equal(updatedProject.WantedSupervisorId, result.WantedSupervisorId);
            Assert.Equal(updatedProject.Start, result.Start);
            Assert.Equal(updatedProject.End, result.End);

        }

        [Fact]
        public void NotUpdateByNonExistingId()
        {
            _repo.Setup(r => r.Get(It.IsAny<int>())).Returns(() => null);
            var projectToUpdate = new ProjectBO{Id = 1};
            var result = _service.Update(projectToUpdate);
            Assert.Null(result);
        }
    }
}
