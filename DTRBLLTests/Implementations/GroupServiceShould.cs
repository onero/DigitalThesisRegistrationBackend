using System.Collections.Generic;
using DTRBLL.BusinessObjects;
using DTRBLL.Services;
using DTRBLL.Services.Implementations;
using DTRDAL.Entities;
using DTRDAL.Repositories;
using DTRDAL.UOW;
using Moq;
using Xunit;

namespace DTRBLLTests.Implementations
{
    public class GroupServiceShould : IServiceTest
    {
        private readonly Mock<IUnitOfWork> _uow = new Mock<IUnitOfWork>();
        private readonly Mock<IGroupRepository> _repo = new Mock<IGroupRepository>();
        private readonly IGroupService _service;

        public GroupServiceShould()
        {
            _uow.SetupGet(r => r.GroupRepository).Returns(_repo.Object);
            _service = new GroupService(_uow.Object);
        }

        private readonly GroupBO MockGroupBO = new GroupBO
        {
            Id = 1,
            Name = "D4FF",
            ContactEmail = "Test",
            Students = new List<StudentBO>{new StudentBO()},
            StudentIds = new List<int>()
        };

        private GroupBO CreateMockGroupBO()
        {
            var bo =_service.Create(MockGroupBO);
            return bo;
        }

        [Fact]
        public void CreateOne()
        {
            _repo.Setup(r => r.Create(It.IsAny<Group>())).Returns(new Group());

            var bo = CreateMockGroupBO();
            Assert.NotNull(bo);
        }

        [Fact]
        public void GetOneByExistingId()
        {
            _repo.Setup(r => r.Get(It.IsAny<int>())).Returns(new Group
            {
                Id = 1,
                Name = "Test",
                ContactEmail = "Test",
                Students = new List<Student>
                {
                    new Student
                    {
                        Id = 1,
                        FirstName = "Test",
                        GroupId = 1,
                        LastName = "Test"
                    }
                }
            });

            var entity = _service.Get(1);
            Assert.NotNull(entity);
            Assert.NotNull(entity.Students);
            Assert.NotEmpty(entity.Students);
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
            _repo.Setup(r => r.GetAll()).Returns(new List<Group>{new Group()});

            var entities = _service.GetAll();
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

        public void UpdateByExistingId()
        {
            throw new System.NotImplementedException();
        }

        public void NotUpdateByNonExistingId()
        {
            throw new System.NotImplementedException();
        }
    }
}