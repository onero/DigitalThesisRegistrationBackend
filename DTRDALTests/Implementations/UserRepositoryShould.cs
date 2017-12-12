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
                Salt = new byte[1] 
            };
            var createdEntity = _repository.Create(entity);
            _context.SaveChanges();
            //return createdEntity;
            return entity;
        }
        [Fact]
        public void CreateOne()
        {
            
        }
    }
}
