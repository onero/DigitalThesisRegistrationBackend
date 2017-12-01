using DTRBLL.BusinessObjects;
using DTRBLL.Converters.Implementations;
using DTRDAL.Entities;
using Xunit;

namespace DTRBLLTests.Implementations.Converters
{
    public class SupervisorConverterShould : IConverterTest
    {
        private readonly SupervisorConverter _converter;

        private Supervisor _mockSupervisor = new Supervisor { Id = 1, FirstName = "Test", LastName = "Test" };
        private SupervisorBO _mockSupervisorBO = new SupervisorBO { Id = 1, FirstName = "TestBO", LastName = "TestBO" };

        public SupervisorConverterShould()
        {
            _converter = new SupervisorConverter();
        }

        [Fact]
        public void ConvertEntity()
        {
            var bo = _converter.Convert(_mockSupervisor);
            Assert.Contains(_mockSupervisor.FirstName, bo.FirstName);
        }

        [Fact]
        public void ConvertBO()
        {
            var entity = _converter.Convert(_mockSupervisorBO);
            Assert.Contains(_mockSupervisorBO.FirstName, entity.FirstName);
        }
        [Fact]
        public void NotConvertEntity_WithNull()
        {
            Supervisor nullEntity = null;
            var bo = _converter.Convert(nullEntity);
            Assert.Null(bo);
        }
        [Fact]
        public void NotConvertBO_WithNull()
        {
            SupervisorBO nullBO = null;
            var entity = _converter.Convert(nullBO);
            Assert.Null(entity);
        }
    }
}
