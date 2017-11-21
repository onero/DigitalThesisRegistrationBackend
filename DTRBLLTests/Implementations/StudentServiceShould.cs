using DTRBLL.BusinessObjects;
using DTRBLL.Services;
using DTRBLL.Services.Implementations;
using DTRDAL.Entities;
using DTRDAL.Repositories;
using DTRDAL.UOW;
using Moq;
using Xunit;

namespace DTRBLLTests.Implementations
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
            throw new System.NotImplementedException();
        }
        [Fact]
        public void NotGetOneByNonExistingId()
        {
            throw new System.NotImplementedException();
        }
        [Fact]
        public void GetAll()
        {
            throw new System.NotImplementedException();
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