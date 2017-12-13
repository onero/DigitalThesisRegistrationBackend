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
    public class UserRepositoryShould
    {
        private readonly DTRContext _context;
        private readonly IUserRepository _repository;

        public UserRepositoryShould()
        {
            _context = TestContext.Context;
            _repository = new UserRepository(_context);
        }
        private User CreateMockUser()
        {
            var entity = new User
            {
                Id = 1,
                Username = "Test",
                PasswordHash = new byte[1],
                Salt = new byte[1],
                Role = "Administrator"
            };
            var createdEntity = _repository.Create(entity);
            _context.SaveChanges();
            return createdEntity;
        }
        [Fact]
        public void CreateOne()
        {
            var createdEntity = CreateMockUser();
            Assert.NotNull(createdEntity);
        }

        [Fact]
        public void GetUser()
        {
            var entityToSearchFor = CreateMockUser();
            var result = _repository.Get(entityToSearchFor.Username);
            Assert.NotNull(result);
        }
        
        [Fact]
        public void NotGetOneByNonExistingId()
        {
            var entity = _repository.Get("Test");
            Assert.Null(entity);
        }
    }
}
