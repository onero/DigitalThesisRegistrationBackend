using DTRBLL.Services;
using DTRDAL.UOW;
using Moq;
using Xunit;

namespace DTRControllerTests.Implementations
{
    public class StudentsControllerShould : IControllerTest
    {
        private Mock<IUnitOfWork> uow = new Mock<IUnitOfWork>();
        private IStudentService _service;

        public StudentsControllerShould()
        {
            _service = new StudentService(uow);
        }
        public void GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void GetByExistingId()
        {
            throw new System.NotImplementedException();
        }

        public void NotGetByNonExistingId_ReturnNotFound()
        {
            throw new System.NotImplementedException();
        }

        public void PostWithValidObject()
        {
            throw new System.NotImplementedException();
        }

        public void NotPostWithInvalidObject_ReturnBadRequest()
        {
            throw new System.NotImplementedException();
        }

        public void NotPostWithNull_ReturnBadRequest()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteByExistingId_ReturnOk()
        {
            throw new System.NotImplementedException();
        }

        public void NotDeleteByNonExistingId_ReturnNotFound()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateWithValidObject_ReturnOk()
        {
            throw new System.NotImplementedException();
        }

        public void NotUpdateWithNull_ReturnBadRequest()
        {
            throw new System.NotImplementedException();
        }

        public void NotUpdateWithMisMatchingIds_ReturnBadRequest()
        {
            throw new System.NotImplementedException();
        }

        public void NotUpdateWithInvalidObject_ReturnBadRequest()
        {
            throw new System.NotImplementedException();
        }

        public void NotUpdateWithNonExistingId_ReturnNotFound()
        {
            throw new System.NotImplementedException();
        }
    }
}
