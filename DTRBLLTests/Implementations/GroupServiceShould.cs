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
            Students = new List<StudentBO>(),
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