using DTRBLL.BusinessObjects;
using DTRBLL.Converters.Implementations;
using DTRDAL.Entities;
using Xunit;

namespace DTRBLLTests.Implementations.Converters
{
    public class AppendixConverterShould : IConverterTest
    {
        private readonly AppendixConverter _converter;

        public AppendixConverterShould()
        {
            _converter = new AppendixConverter();
        }

        private readonly Appendix MockAppendix = new Appendix
        {
            Condition = "Test",
            Resources = "Test"
        };
        private readonly AppendixBO MockAppendixBO = new AppendixBO()
        {
            Condition = "Test",
            Resources = "Test"
        };

        [Fact]
        public void ConvertEntity()
        {
            var bo = _converter.Convert(MockAppendix);
            Assert.NotNull(bo);
            Assert.Contains(MockAppendix.Condition, bo.Condition);
            Assert.Contains(MockAppendix.Resources, bo.Resources);
        }

        [Fact]
        public void ConvertBO()
        {
            var entity = _converter.Convert(MockAppendixBO);
            Assert.NotNull(entity);
            Assert.Contains(MockAppendixBO.Condition, entity.Condition);
            Assert.Contains(MockAppendixBO.Resources, entity.Resources);
        }

        [Fact]
        public void NotConvertEntity_WithNull()
        {
            Appendix entity = null;
            var convertedBO = _converter.Convert(entity);
            Assert.Null(convertedBO);
        }

        [Fact]
        public void NotConvertBO_WithNull()
        {
            AppendixBO bo = null;
            var convertedEntity = _converter.Convert(bo);
            Assert.Null(convertedEntity);
        }
    }
}