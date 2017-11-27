using System;
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
    public class SupervisorServiceShould : IServiceTest
    {
        private readonly Mock<IUnitOfWork> _uow = new Mock<IUnitOfWork>();
        private readonly Mock<ISupervisorRepository> _repo = new Mock<ISupervisorRepository>();
        private readonly ISupervisorService _service;


        public SupervisorServiceShould()
        {
            _uow.SetupGet(r => r.SupervisorRepository).Returns(_repo.Object);
            _service = new SupervisorService(_uow.Object);
        }


        [Fact]
        public void CreateOne()
        {
            _repo.Setup(r => r.Create(It.IsAny<Supervisor>())).Returns(new Supervisor());

            var entity = _service.Create(new SupervisorBO());

            Assert.NotNull(entity);

        }
        [Fact]
        public void GetOneByExistingId()
        {
            _repo.Setup(r => r.Get(It.IsAny<int>())).Returns(new Supervisor());

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
            _repo.Setup(r => r.GetAll()).Returns(new List<Supervisor> { new Supervisor() });

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
            throw new NotImplementedException();
        }

        public void NotUpdateByNonExistingId()
        {
            throw new NotImplementedException();
        }
    }
}
