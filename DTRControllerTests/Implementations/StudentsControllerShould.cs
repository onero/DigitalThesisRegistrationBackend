using System.Collections.Generic;
using DigitalThesisRegistration.Controllers;
using DTRBLL.BusinessObjects;
using DTRBLL.Services;
using DTRBLL.Services.Implementations;
using DTRDAL.UOW;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DTRControllerTests.Implementations
{
    public class StudentsControllerShould : IControllerTest
    {
        private Mock<IStudentService> _service = new Mock<IStudentService>();
        private StudentsController _controller;
        private readonly StudentBO _mockBo = new StudentBO{Id = 1, FirstName = "Test", LastName = "Test"};

        public StudentsControllerShould()
        {
            _controller = new StudentsController(_service.Object);
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
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void PostWithValidObject()
        {
            _service.Setup(s => s.Create(It.IsAny<StudentBO>())).Returns(_mockBo);
            var result = _controller.Post(_mockBo);
            Assert.NotNull(result);
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
