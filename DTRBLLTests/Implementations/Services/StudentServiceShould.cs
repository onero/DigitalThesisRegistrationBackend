using System.Collections.Generic;
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
    public class StudentServiceShould : IServiceTest
    {
        private readonly Mock<IUnitOfWork> _uow = new Mock<IUnitOfWork>();
        private readonly Mock<IStudentRepository> _repo = new Mock<IStudentRepository>();
        private readonly IStudentService _service;
        

        public StudentServiceShould()
        {
            _uow.SetupGet(r => r.StudentRepository).Returns(_repo.Object);
            _service = new StudentService(_uow.Object);
        }


        [Fact]
        public void CreateOne()
        {
            _repo.Setup(r => r.Create(It.IsAny<Student>())).Returns(new Student());

            var entity = _service.Create(new StudentBO());

            Assert.NotNull(entity);

        }
        [Fact]
        public void GetOneByExistingId()
        {
            _repo.Setup(r => r.Get(It.IsAny<int>())).Returns(new Student());

            var entity = _service.Get(1);

            Assert.NotNull(entity);
        }
        [Fact]
        public void NotGetOneByNonExistingId()
        {
            var entity = _service.Get(0);
            Assert.Null(entity);
        }
        [Fact]
        public void GetAll()
        {
            _repo.Setup(r => r.GetAll()).Returns(new List<Student> {new Student()});

            var entities = _service.GetAll();

            Assert.NotNull(entities);
            Assert.NotEmpty(entities);
        }

        public void DeleteByExistingId()
        {
            throw new System.NotImplementedException();
        }

        public void NotDeleteByNonExistingId()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateByExistingId()
        {
            throw new System.NotImplementedException();
        }

        public void NotUpdateByNonExistingId()
        {
            throw new System.NotImplementedException();
        }
    }
}