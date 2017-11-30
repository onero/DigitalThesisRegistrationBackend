using System;
using System.Collections.Generic;
using DigitalThesisRegistration.Controllers;
using DTRBLL.BusinessObjects;
using DTRBLL.Services;
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
            Assert.IsType<BadRequestResult>(result);
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

        public void UpdateWithValidObject_ReturnOk()
        {
            throw new System.NotImplementedException();
        }

        public void NotUpdateWithNull_ReturnBadRequest()
        {
            throw new System.NotImplementedException();
        }

        public void NotUpdateWithMisMatchingIds_ReturnBadRequest()
        {
            throw new System.NotImplementedException();
        }

        public void NotUpdateWithInvalidObject_ReturnBadRequest()
        {
            throw new System.NotImplementedException();
        }

        public void NotUpdateWithNonExistingId_ReturnNotFound()
        {
            throw new System.NotImplementedException();
        }
    }
}