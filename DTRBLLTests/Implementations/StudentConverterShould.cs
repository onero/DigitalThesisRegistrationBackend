using DTRBLL.BusinessObjects;
using DTRBLL.Converters.Implementations;
using DTRDAL.Entities;
using Xunit;

namespace DTRBLLTests.Implementations
{
    public class StudentConverterShould : IConverterTest
    {
        private readonly StudentConverter _converter;

        private Student _mockStudent = new Student{Id = 1, FirstName = "Test", LastName = "Test"};
        private StudentBO _mockStudentBO = new StudentBO{Id = 1, FirstName = "TestBO", LastName = "TestBO"};

        public StudentConverterShould()
        {
            _converter = new StudentConverter();
        }

        [Fact]
        public void ConvertEntity()
        {
            var bo = _converter.Convert(_mockStudent);
            Assert.Contains(_mockStudent.FirstName, bo.FirstName);
        }

        [Fact]
        public void ConvertBO()
        {
            var entity = _converter.Convert(_mockStudentBO);
            Assert.Contains(_mockStudentBO.FirstName, entity.FirstName);
        }
        [Fact]
        public void NotConvertEntity_WithNull()
        {
            Student nullEntity = null;
            var bo = _converter.Convert(nullEntity);
            Assert.Null(bo);
        }
        [Fact]
        public void NotConvertBO_WithNull()
        {
            StudentBO nullBO = null;
            var entity = _converter.Convert(nullBO);
            Assert.Null(entity);
        }
    }
}
