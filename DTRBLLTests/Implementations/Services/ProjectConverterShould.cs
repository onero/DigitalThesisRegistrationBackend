using System;
using DTRBLL.BusinessObjects;
using DTRBLL.Converters.Implementations;
using DTRDAL.Entities;
using Xunit;

namespace DTRBLLTests.Implementations.Services
{
    public class ProjectConverterShould : IConverterTest
    {
        private ProjectConverter _converter;
        private Project _mockProject = new Project
        {
            Id = 1,
            Description = "Test",
            End = new DateTime(2017, 1, 2, 1, 1, 1),
            Start = new DateTime(2017, 1, 1, 1, 1, 1),
            Title = "Test",
            WantedSuporvisorId = 1,
            AssignedSuporvisorId = 1
        };

        private ProjectBO _mockProjectBo = new ProjectBO
        {
            Id = 1,
            Description = "TestBO",
            End = new DateTime(2017, 1, 2, 1, 1, 1),
            Start = new DateTime(2017, 1, 1, 1, 1, 1),
            Title = "TestBO",
            WantedSuporvisorId = 1,
            AssignedSuporvisorId = 1
        };

        public ProjectConverterShould()
        {
            _converter = new ProjectConverter();
        }

        [Fact]
        public void ConvertEntity()
        {
            var bo = _converter.Convert(_mockProject);
            Assert.Contains(_mockProject.Title, bo.Title);
        }

        [Fact]
        public void ConvertBO()
        {
            var ent = _converter.Convert(_mockProjectBo);
            Assert.Contains(_mockProjectBo.Title, ent.Title);
        }

        [Fact]
        public void NotConvertEntity_WithNull()
        {
            Project nullEntity = null;
            var bo = _converter.Convert(nullEntity);
            Assert.Null(bo);
        }

        [Fact]  
        public void NotConvertBO_WithNull()
        {
            ProjectBO nullEntity = null;
            var ent = _converter.Convert(nullEntity);
            Assert.Null(ent);
        }
    }
}
