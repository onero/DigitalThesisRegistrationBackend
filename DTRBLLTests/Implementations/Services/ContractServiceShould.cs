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
    public class ContractServiceShould : IServiceTest
    {
        private readonly Mock<IUnitOfWork> _uow = new Mock<IUnitOfWork>();
        private readonly Mock<IContractRepository> _repository = new Mock<IContractRepository>();
        private readonly IContractService _service;

        public ContractServiceShould()
        {
            _uow.SetupGet(r => r.ContractRepository).Returns(_repository.Object);
            _service = new ContractService(_uow.Object);
        }

        private readonly Contract MockContract = new Contract
        {
            ProjectId = 1,
            GroupId = 1,
            CompanyId = 1,
            IsApproved = true
        };
        private readonly ContractBO MockContractBO = new ContractBO
        {
            ProjectId = 1,
            GroupId = 1,
            CompanyId = 1,
            IsApproved = true
        };

        [Fact]
        public void CreateOne()
        {
            _repository.Setup(r => r.Create(It.IsAny<Contract>())).Returns(MockContract);
            var createdEntity = _service.Create(MockContractBO);
            Assert.NotNull(createdEntity);
        }
        [Fact]
        public void GetOneByExistingId()
        {
            _repository.Setup(r => r.Get(1, 1, 1)).Returns(MockContract);
            var entityFromDB = _service.Get(MockContractBO.ProjectId, MockContractBO.GroupId, MockContractBO.CompanyId);
            Assert.NotNull(entityFromDB);
        }
        [Fact]
        public void NotGetOneByNonExistingId()
        {
            _repository.Setup(r => r.Get(0, 0, 0)).Returns(() => null);
            var result = _service.Get(0, 0, 0);
            Assert.Null(result);
        }
        [Fact]
        public void GetAll()
        {
            _repository.Setup(r => r.GetAll()).Returns(new List<Contract>{MockContract});
            var result = _service.GetAll();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
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