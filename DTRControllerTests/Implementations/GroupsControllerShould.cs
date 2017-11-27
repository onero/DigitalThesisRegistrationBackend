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

            var result = _controller.Post(new GroupBO {Id = 1, ContactEmail = "Test", Students = new List<StudentBO>()});
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void NotPostWithInvalidObject_ReturnBadRequest()
        {
            _controller.ModelState.AddModelError("", "");
            var result = _controller.Post(new GroupBO{Id = 1});
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
            throw new System.NotImplementedException();
        }
        public void NotDeleteByNonExistingId_ReturnNotFound()
        {
            throw new System.NotImplementedException();
        }
        [Fact]
        public void UpdateWithValidObject_ReturnOk()
        {
            _service.Setup(r => r.Update(It.IsAny<GroupBO>())).Returns((GroupBO group) => group);
            var result = _controller.Put(1, new GroupBO{Id = 1, ContactEmail = "D4FF"});
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void NotUpdateWithNull_ReturnBadRequest()
        {
            _service.Setup(r => r.Update(It.IsAny<GroupBO>())).Returns(() => null);
            var result = _controller.Put(0, null);
            Assert.IsType<BadRequestResult>(result);
        }
        [Fact]
        public void NotUpdateWithMisMatchingIds_ReturnBadRequest()
        {
            var result = _controller.Put(0, new GroupBO {Id = 1});
            Assert.IsType<BadRequestResult>(result);
        }
        [Fact]
        public void NotUpdateWithInvalidObject_ReturnBadRequest()
        {
            _controller.ModelState.AddModelError("", "");
            var result = _controller.Put(1, new GroupBO());
            Assert.IsType<BadRequestObjectResult>(result);
        }
        [Fact]
        public void NotUpdateWithNonExistingId_ReturnNotFound()
        {
            _service.Setup(r => r.Get(0)).Returns(() => null);
            var result = _controller.Put(0, new GroupBO{Id = 0, ContactEmail = "D4ff"});
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}