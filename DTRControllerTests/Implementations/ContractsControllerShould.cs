using System;
using System.Collections.Generic;
using DigitalThesisRegistration.Controllers;
using DTRBLL.BusinessObjects;
using DTRBLL.Services;
using DTRDAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DTRControllerTests.Implementations
{
    public class ContractsControllerShould : IControllerTest
    {
        private readonly Mock<IContractService> _service = new Mock<IContractService>();
        private readonly Mock<IProjectService> _projectService = new Mock<IProjectService>();
        private readonly ContractsController _controller;
        private readonly ContractBO _mockContractBo = new ContractBO
        {
            ProjectId = 1,
            CompanyId = 1,
            GroupId = 1
        };

        public ContractsControllerShould()
        {
            _controller = new ContractsController(_service.Object, _projectService.Object);
        }

        [Fact]
        public void GetAll()
        {
            _service.Setup(s => s.GetAll()).Returns(new List<ContractBO> {new ContractBO()});
            var result = _controller.Get();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
        [Fact]
        public void GetByExistingId()
        {
            _service.Setup(s => s.Get(1, 1, 1)).Returns(new ContractBO());
            var result = _controller.Get(1, 1, 1);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetByGroupId()
        {
            _service.Setup(s => s.Get(1)).Returns(new ContractBO());
            var result = _controller.Get(1);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void NotGetByNonExistingId_ReturnNotFound()
        {
            _service.Setup(s => s.Get(0, 0, 0)).Returns(() => null);
            var result = _controller.Get(0, 0, 0);
            Assert.IsType<NotFoundObjectResult>(result);
        }
        [Fact]
        public void PostWithValidObject()
        {
            _service.Setup(r => r.Create(It.IsAny<ContractBO>())).Returns(new ContractBO());
            var result = _controller.Post(new ContractBO
            {
                ProjectId = 1
            });
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void NotPostWithInvalidObject_ReturnBadRequest()
        {
            _controller.ModelState.AddModelError("", "");
            var result = _controller.Post(new ContractBO());
            Assert.IsType<BadRequestObjectResult>(result);
        }
        [Fact]
        public void NotPostWithNull_ReturnBadRequest()
        {
            var result = _controller.Post(null);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void CreateProjectWithWhenProjectIdIsZero()
        {
            var projectID = 1;
            _projectService.Setup(s => s.Create(It.IsAny<ProjectBO>())).Returns(new ProjectBO
            {
                Id = projectID
            });
            _service.Setup(s => s.Create(It.IsAny<ContractBO>())).Returns((ContractBO contract) => contract);
            var result = (OkObjectResult) _controller.Post(new ContractBO
            {
                CompanyId = 1,
                GroupId = 1,
            });
            Assert.True(projectID == ((ContractBO) result.Value).ProjectId);
        }

        public void DeleteByExistingId_ReturnOk()
        {
            throw new System.NotImplementedException();
        }

        public void NotDeleteByNonExistingId_ReturnNotFound()
        {
            throw new System.NotImplementedException();
        }

        [Fact]
        public void UpdateWithValidObject_ReturnOk()
        {
            _service.Setup(s => s.Update(It.IsAny<ContractBO>())).Returns(_mockContractBo);
            var updatedBO = _controller.Put(
                _mockContractBo.ProjectId,
                _mockContractBo.GroupId,
                _mockContractBo.CompanyId,
                _mockContractBo);
            Assert.IsType<OkObjectResult>(updatedBO);
        }

        [Fact]
        public void NotUpdateWithNull_ReturnBadRequest()
        {
            var result = _controller.Put(0,0,0, null);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void NotUpdateWithMisMatchingIds_ReturnBadRequest()
        {
            var result = _controller.Put(0,0,0, new ContractBO
            {
                ProjectId = 1,
                CompanyId = 1,
                GroupId = 1
            });
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void NotUpdateWithMisMatchingProject_ReturnBadRequest()
        {
            var result = _controller.Put(0, 1, 1, new ContractBO
            {
                ProjectId = 1,
                CompanyId = 1,
                GroupId = 1
            });
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void NotUpdateWithMisMatchingCompanyId_ReturnBadRequest()
        {
            var result = _controller.Put(1, 0, 1, new ContractBO
            {
                ProjectId = 1,
                CompanyId = 1,
                GroupId = 1
            });
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void NotUpdateWithMisMatchingGroupId_ReturnBadRequest()
        {
            var result = _controller.Put(1, 1, 0, new ContractBO
            {
                ProjectId = 1,
                CompanyId = 1,
                GroupId = 1
            });
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void NotUpdateWithInvalidObject_ReturnBadRequest()
        {
            _controller.ModelState.AddModelError("", "");
            var result = _controller.Put(1,1,1, _mockContractBo);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void NotUpdateWithNonExistingId_ReturnNotFound()
        {
            _service.Setup(s => s.Update(It.IsAny<ContractBO>())).Returns(() => null);
            var result = _controller.Put(1, 1, 1, _mockContractBo);
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}