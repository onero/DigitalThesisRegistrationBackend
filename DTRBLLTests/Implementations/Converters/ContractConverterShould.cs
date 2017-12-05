using DTRBLL.BusinessObjects;
using DTRBLL.Converters.Implementations;
using DTRDAL.Entities;
using Xunit;

namespace DTRBLLTests.Implementations.Converters
{
    public class ContractConverterShould : IConverterTest
    {
        private readonly ContractConverter _converter;

        public ContractConverterShould()
        {
            _converter = new ContractConverter();
        }

        private readonly Contract MockContract = new Contract
        {
            CompanyId = 1,
            GroupId = 1,
            ProjectId = 1,
            SupervisorApproved = true,
            AdminApproved = true
        };
        private readonly ContractBO MockContractBO = new ContractBO
        {
            CompanyId = 1,
            GroupId = 1,
            ProjectId = 1,
            SupervisorApproved = true,
            AdminApproved = true
        };

        [Fact]
        public void ConvertEntity()
        {
            var bo = _converter.Convert(MockContract);
            Assert.NotNull(bo);
        }
        [Fact]
        public void ConvertBO()
        {
            var entity = _converter.Convert(MockContractBO);
            Assert.NotNull(entity);
        }
        [Fact]
        public void NotConvertEntity_WithNull()
        {
            Contract entity = null;
            var bo = _converter.Convert(entity);
            Assert.Null(bo);
        }
        [Fact]
        public void NotConvertBO_WithNull()
        {
            ContractBO bo = null;
            var entity = _converter.Convert(bo);
            Assert.Null(entity);
        }
    }
}