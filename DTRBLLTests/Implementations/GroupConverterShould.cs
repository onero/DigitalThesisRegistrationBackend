using System.Collections.Generic;
using DTRBLL.BusinessObjects;
using DTRBLL.Converters.Implementations;
using DTRDAL.Entities;
using Xunit;

namespace DTRBLLTests.Implementations
{
    public class GroupConverterShould : IConverterTest
    {
        private readonly GroupConverter _converter;

        public GroupConverterShould()
        {
            _converter = new GroupConverter();
        }

        private readonly Group MockGroup = new Group
        {
            Id = 1,
            Name = "D4FF",
            ContactEmail = "Test",
            Students = new List<Student> { new Student()}
        };

        private readonly GroupBO MockGroupBO = new GroupBO
        {
            Id = 1,
            Name = "D4FF",
            ContactEmail = "Test",
            Students = new List<StudentBO> { new StudentBO()}
        };

        [Fact]
        public void ConvertEntity()
        {
            var bo = _converter.Convert(MockGroup);
            Assert.NotNull(bo);
            Assert.NotNull(bo.Students);
            Assert.NotEmpty(bo.Students);
        }


        [Fact]
        public void NotConvertEntity_WithNull()
        {
            Group group = null;
            var bo = _converter.Convert(group);
            Assert.Null(bo);
        }

        [Fact]
        public void ConvertBO()
        {
            var entity = _converter.Convert(MockGroupBO);
            Assert.NotNull(entity);
            Assert.NotNull(entity.Students);
            Assert.NotEmpty(entity.Students);
        }

        [Fact]
        public void NotConvertBO_WithNull()
        {
            GroupBO bo = null;
            var entity = _converter.Convert(bo);
            Assert.Null(entity);
        }
    }
}