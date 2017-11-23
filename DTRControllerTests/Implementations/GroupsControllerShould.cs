using System.Collections.Generic;
using DigitalThesisRegistration.Controllers;
using DTRBLL.BusinessObjects;
using DTRBLL.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DTRControllerTests.Implementations
{
    public class GroupsControllerShould : IControllerTest
    {
        private readonly Mock<IGroupService> _service = new Mock<IGroupService>();
        private readonly GroupsController _controller;

        public GroupsControllerShould()
        {
            _controller = new GroupsController(_service.Object);
        }


        [Fact]
        public void GetAll()
        {
            _service.Setup(r => r.GetAll()).Returns(new List<GroupBO>{new GroupBO()});

            var result = _controller.Get();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
        [Fact]
        public void GetByExistingId()
        {
            _service.Setup(r => r.Get(It.IsAny<int>())).Returns(new GroupBO());

            var result = _controller.Get(1);
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void NotGetByNonExistingId_ReturnNotFound()
        {
            var result = _controller.Get(0);
            Assert.IsType<NotFoundObjectResult>(result);
        }
        [Fact]
        public void PostWithValidObject()
        {
            _service.Setup(r => r.Create(It.IsAny<GroupBO>())).Returns(new GroupBO());

            var result = _controller.Post(new GroupBO {Id = 1, Name = "D4FF", ContactEmail = "Test", Students = new List<StudentBO>(), StudentIds = new List<int>()});
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void NotPostWithInvalidObject_ReturnBadRequest()
        {
            _controller.ModelState.AddModelError("", "");
            var result = _controller.Post(new GroupBO());
            Assert.IsType<BadRequestResult>(result);
        }
        [Fact]
        public void NotPostWithNull_ReturnBadRequest()
        {
            var result = _controller.Post(null);
            Assert.Null(result);
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