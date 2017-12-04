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
    public class StudentsControllerShould : IControllerTest
    {
        public StudentsControllerShould()
        {
            _controller = new StudentsController(_service.Object);
        }

        private readonly Mock<IStudentService> _service = new Mock<IStudentService>();
        private readonly StudentsController _controller;
        private readonly StudentBO _mockBo = new StudentBO {Id = 1, FirstName = "Test", LastName = "Test"};

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
            _service.Setup(r => r.Update(It.IsAny<StudentBO>())).Returns((StudentBO student) => student);
            var result = _controller.Put(1, new StudentBO
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test",
                GroupId = 1
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
            var result = _controller.Put(0, new StudentBO
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test"
            });
            Assert.IsType<BadRequestObjectResult>(result);
        }
        [Fact]
        public void NotUpdateWithInvalidObject_ReturnBadRequest()
        {
            _controller.ModelState.AddModelError("", "");
            var result = _controller.Put(1, new StudentBO{Id = 1});
            Assert.IsType<BadRequestObjectResult>(result);
        }
        [Fact]
        public void NotUpdateWithNonExistingId_ReturnNotFound()
        {
            _service.Setup(r => r.Update(It.IsAny<StudentBO>())).Returns(() => null);
            var result = _controller.Put(1, new StudentBO {Id = 1});
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void GetAll()
        {
            _service.Setup(s => s.GetAll()).Returns(new List<StudentBO> {_mockBo});
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
        public void NotPostWithInvalidObject_ReturnBadRequest()
        {
            _service.Setup(s => s.Create(It.IsAny<StudentBO>())).Returns(() => null);
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

        [Fact]
        public void PostWithValidObject()
        {
            _service.Setup(s => s.Create(It.IsAny<StudentBO>())).Returns(_mockBo);
            var result = _controller.Post(_mockBo);
            Assert.NotNull(result);
        }
    }
}