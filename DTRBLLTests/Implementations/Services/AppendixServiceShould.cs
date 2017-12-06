using DTRBLL.BusinessObjects;
using DTRBLL.Services;
using DTRBLL.Services.Implementations;
using DTRDAL.Entities;
using DTRDAL.Repositories;
using DTRDAL.UOW;
using Moq;
using Xunit;

namespace DTRBLLTests.Implementations.Services
{
    public class AppendixServiceShould
    {
        private readonly Mock<IUnitOfWork> _uow = new Mock<IUnitOfWork>();
        private readonly Mock<IAppendixRepository> _repository = new Mock<IAppendixRepository>();
        private readonly IAppendixService _service;

        public AppendixServiceShould()
        {
            _uow.SetupGet(r => r.AppendixRepository).Returns(_repository.Object);
            _service = new AppendixService(_uow.Object);
        }

        [Fact]
        public void SaveAppendix()
        {
            _repository.Setup(r => r.Save(It.IsAny<Appendix>())).Returns(() => true);
            var appendixToSave = new AppendixBO
            {
                Condition = "Test",
                Resources = "Test"
            };
            var saved = _service.Save(appendixToSave);
            Assert.True(saved);
        }

        [Fact]
        public void LoadExistingAppendix()
        {
            _repository.Setup(r => r.Load()).Returns(() => new Appendix
            {
                Condition = "Test",
                Resources = "Test"
            });
            var appendix = _service.Load();
            Assert.NotNull(appendix);
        }
    }
}