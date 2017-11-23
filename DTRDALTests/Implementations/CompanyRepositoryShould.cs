using System;
using System.Collections.Generic;
using System.Text;
using DTRDAL.Context;
using DTRDAL.Entities;
using DTRDAL.Repositories;
using DTRDAL.Repositories.Implementations;
using DTRDALTests.implementations;
using Xunit;

namespace DTRDALTests.Implementations
{
    public class CompanyRepositoryShould : IRepositoryTest
    {
        private readonly DTRContext _context;
        private readonly CompanyRepository _repository;

        public CompanyRepositoryShould()
        {
            _context = TestContext.Context;
            _repository = new CompanyRepository(_context);
        }

        private Company CreateMockCompany()
        {
            var entity = new Company { Id = 1, Name = "Test" };
            var createdEntity = _repository.Create(entity);
            _context.SaveChanges();
            return createdEntity;
        }

        [Fact]
        public void CreateOne()
        {
            var createdEntity = CreateMockCompany();
            Assert.NotNull(createdEntity);
        }

        [Fact]
        public void GetOneByExistingId()
        {
            var createdEntity = CreateMockCompany();
            var entity = _repository.Get(createdEntity.Id);
            Assert.NotNull(entity);
        }

        [Fact]
        public void NotGetOneByNonExistingId()
        {
            var entity = _repository.Get(0);
            Assert.Null(entity);
        }

        [Fact]
        public void GetAll()
        {
            CreateMockCompany();
            var entities = _repository.GetAll();
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
    }
}
