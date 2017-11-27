using DTRBLL.BusinessObjects;
using DTRBLL.Converters.Implementations;
using DTRDAL.Entities;
using Xunit;

namespace DTRBLLTests.Implementations.Converters
{
    public class CompanyConverterShould : IConverterTest
    {
        private readonly CompanyConverter _converter;

        private Company _mockCompany = new Company { Id = 1, Name = "Test" };
        private CompanyBO _mockCompanyBO = new CompanyBO { Id = 1, Name = "TestBO" };

        public CompanyConverterShould()
        {
            _converter = new CompanyConverter();
        }

        [Fact]
        public void ConvertEntity()
        {
            var bo = _converter.Convert(_mockCompany);
            Assert.Contains(_mockCompany.Name, bo.Name);
        }

        [Fact]
        public void ConvertBO()
        {
            var entity = _converter.Convert(_mockCompanyBO);
            Assert.Contains(_mockCompanyBO.Name, entity.Name);
        }

        [Fact]
        public void NotConvertEntity_WithNull()
        {
            Company nullEntity = null;
            var bo = _converter.Convert(nullEntity);
            Assert.Null(bo);
        }

        [Fact]
        public void NotConvertBO_WithNull()
        {
            CompanyBO nullEntity = null;
            var entity = _converter.Convert(nullEntity);
            Assert.Null(entity);
        }
    }
}