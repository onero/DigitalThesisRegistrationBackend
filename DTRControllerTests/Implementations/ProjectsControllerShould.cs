using System;
using System.Collections.Generic;
using System.Text;
using DigitalThesisRegistration.Controllers;
using DTRBLL.BusinessObjects;
using DTRBLL.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DTRControllerTests.Implementations
{
    public class ProjectsControllerShould : IControllerTest
    {
        private readonly Mock<IProjectService> _service = new Mock<IProjectService>();
        private readonly ProjectsController _controller;
        private readonly ProjectBO _mockBo = new ProjectBO()
        {
            Id = 1,
            Description = "Test",
            End = new DateTime(2017, 1, 2, 1, 1, 1),
            Start = new DateTime(2017, 1, 1, 1, 1, 1),
            Title = "Test",
            WantedSupervisorId = 1,
            AssignedSupervisorId = 1
        };

        public ProjectsControllerShould()
        {
            _controller = new ProjectsController(_service.Object);
        }

        [Fact]
        public void GetAll()
        {
            _service.Setup(s => s.GetAll()).Returns(new List<ProjectBO> { _mockBo });
            var result = _controller.Get();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetByExistingId()
        {
            _service.Setup(s => s.Get(It.IsAny<int>())).Returns(_mockBo);
            var result = _controller.Get(_mockBo.Id);
            Assert.NotNull(result);
        }

        [Fact]
        public void NotGetByNonExistingId_ReturnNotFound()
        {
            _service.Setup(s => s.Get(0)).Returns(() => null);
            var result = _controller.Get(0);
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void PostWithValidObject()
        {
            _service.Setup(s => s.Create(It.IsAny<ProjectBO>())).Returns(_mockBo);
            var result = _controller.Post(_mockBo);
            Assert.NotNull(result);
        }

        [Fact]
        public void NotPostWithInvalidObject_ReturnBadRequest()
        {
            _controller.ModelState.AddModelError("", "");
            var result = _controller.Post(_mockBo);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void NotPostWithNull_ReturnBadRequest()
        {
            var result = _controller.Post(null);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        public void DeleteByExistingId_ReturnOk()
        {
            throw new NotImplementedException();
        }

        public void NotDeleteByNonExistingId_ReturnNotFound()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void UpdateWithValidObject_ReturnOk()
        {
            _service.Setup(r => r.Update(It.IsAny<ProjectBO>())).Returns((ProjectBO project) => project);
            var result = _controller.Put(1, new ProjectBO
            {
                Id = 1,
                WantedSupervisorId = 1,
                AssignedSupervisorId = 1,
                Title = "Test",
                Description = "Test",
                Start = new DateTime(2017, 1, 1, 1, 1, 1),
                End = new DateTime(2017, 1, 1, 1, 1, 1)
            });
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void NotUpdateWithNull_ReturnBadRequest()
        {
            var result = _controller.Put(1, null);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void NotUpdateWithMisMatchingIds_ReturnBadRequest()
        {
            var result = _controller.Put(0, new ProjectBO
            {
                Id = 1,
                WantedSupervisorId = 1,
                AssignedSupervisorId = 1,
                Title = "Test",
                Description = "Test",
                Start = new DateTime(2017, 1, 1, 1, 1, 1),
                End = new DateTime(2017, 1, 1, 1, 1, 1)
            });
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void NotUpdateWithInvalidObject_ReturnBadRequest()
        {
            _controller.ModelState.AddModelError("", "");
            var result = _controller.Put(1, new ProjectBO { Id = 1 });
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void NotUpdateWithNonExistingId_ReturnNotFound()
        {
            _service.Setup(r => r.Update(It.IsAny<ProjectBO>())).Returns(() => null);
            var result = _controller.Put(1, new ProjectBO { Id = 1 });
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}
