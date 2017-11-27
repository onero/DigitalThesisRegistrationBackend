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
    public class CompanyServiceShould : IServiceTest
    {
        private readonly Mock<IUnitOfWork> _uow = new Mock<IUnitOfWork>();
        private readonly Mock<ICompanyRepository> _repo = new Mock<ICompanyRepository>();
        private readonly ICompanyService _service;

        public CompanyServiceShould()
        {
            _uow.SetupGet(r => r.CompanyRepository).Returns(_repo.Object);
            _service = new CompanyService(_uow.Object);
        }

        [Fact]
        public void CreateOne()
        {
            _repo.Setup(r => r.Create(It.IsAny<Company>())).Returns(new Company());

            var entity = _service.Create(new CompanyBO());

            Assert.NotNull(entity);
        }

        [Fact]
        public void GetOneByExistingId()
        {
            _repo.Setup(r => r.Get(It.IsAny<int>())).Returns(new Company());

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
            _repo.Setup(r => r.GetAll()).Returns(new List<Company> { new Company() });

            var entities = _service.GetAll();

            Assert.NotNull(entities);
            Assert.NotEmpty(entities);
        }

        public void DeleteByExistingId()
        {
            throw new NotImplementedException();
        }

        public void NotDeleteByNonExistingId()
        {
            throw new NotImplementedException();
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
