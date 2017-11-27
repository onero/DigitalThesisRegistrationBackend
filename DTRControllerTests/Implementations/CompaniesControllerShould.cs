using System;
using System.Collections.Generic;
using System.Text;
using DigitalThesisRegistration.Controllers;
using DTRBLL.BusinessObjects;
using DTRBLL.Services;
using DTRDAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DTRControllerTests.Implementations
{
    public class CompaniesControllerShould : IControllerTest
    {
        private Mock<ICompanyService> _service = new Mock<ICompanyService>();
        private CompaniesController _controller;
        private readonly CompanyBO _mockBo = new CompanyBO { Id = 1, Name = "Test" };

        public CompaniesControllerShould()
        {
            _controller = new CompaniesController(_service.Object);
        }

        [Fact]
        public void GetAll()
        {
            _service.Setup(s => s.GetAll()).Returns(new List<CompanyBO> {_mockBo});
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
            _service.Setup(s => s.Create(It.IsAny<CompanyBO>())).Returns(_mockBo);
            var result = _controller.Post(_mockBo);
            Assert.NotNull(result);
        }

        [Fact]
        public void NotPostWithInvalidObject_ReturnBadRequest()
        {
            _service.Setup(s => s.Create(It.IsAny<CompanyBO>())).Returns(() => null);
            _controller.ModelState.AddModelError("", "");
            var result = _controller.Post(_mockBo);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void NotPostWithNull_ReturnBadRequest()
        {
            var result = _controller.Post(null);
            Assert.IsType<BadRequestResult>(result);
        }

        public void DeleteByExistingId_ReturnOk()
        {
            throw new NotImplementedException();
        }

        public void NotDeleteByNonExistingId_ReturnNotFound()
        {
            throw new NotImplementedException();
        }

        public void UpdateWithValidObject_ReturnOk()
        {
            throw new NotImplementedException();
        }

        public void NotUpdateWithNull_ReturnBadRequest()
        {
            throw new NotImplementedException();
        }

        public void NotUpdateWithMisMatchingIds_ReturnBadRequest()
        {
            throw new NotImplementedException();
        }

        public void NotUpdateWithInvalidObject_ReturnBadRequest()
        {
            throw new NotImplementedException();
        }

        public void NotUpdateWithNonExistingId_ReturnNotFound()
        {
            throw new NotImplementedException();
        }
    }
}
