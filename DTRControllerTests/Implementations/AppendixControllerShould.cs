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
    public class AppendixControllerShould
    {
        private readonly Mock<IAppendixService> _service = new Mock<IAppendixService>();
        private readonly AppendixController _controller;

        public AppendixControllerShould()
        {
            _controller = new AppendixController(_service.Object);
        }

        [Fact]
        public void LoadAppendix()
        {
            _service.Setup(s => s.Load()).Returns(new AppendixBO
            {
                Condition = "Test",
                Resources = "Test"
            });
            var result = _controller.Load();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void SaveAppendix()
        {
            _service.Setup(s => s.Save(It.IsAny<AppendixBO>())).Returns(() => true);
            var appendixToSave = new AppendixBO
            {
                Condition = "Test",
                Resources = "Test"
            };
            var result = _controller.Save(appendixToSave);
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
