using System;
using System.Collections.Generic;
using System.Text;
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
    public class UserServiceShould
    {
        private readonly Mock<IUnitOfWork> _uow = new Mock<IUnitOfWork>();
        private readonly Mock<IUserRepository> _repo = new Mock<IUserRepository>();
        private readonly IUserService _service;


        public UserServiceShould()
        {
            _uow.SetupGet(r => r.UserRepository).Returns(_repo.Object);
            _service = new UserService(_uow.Object);
        }


        [Fact]
        public void CreateOne()
        {
            _repo.Setup(r => r.Create(It.IsAny<User>())).Returns(new User());

            var entity = _service.Create(new UserBO
            {
                Username = "Test",
                Password = "Test",
                Role = "Administrator"
            }, new UserDBBO
            {
                Salt = new byte[1],
                PasswordHash = new byte[1]
            });

            Assert.NotNull(entity);
        }

        [Fact]
        public void GetOneByExistingUsername()
        {
            _repo.Setup(r => r.Get(It.IsAny<string>())).Returns(new User());
            
            var userBo = _service.Get("Test").userBo;
            var userDbbo = _service.Get("Test").userDbbo;
            
            Assert.NotNull(userBo);
            Assert.NotNull(userDbbo);
        }

        [Fact]
        public void NotGetOneByNonExistingUsername()
        {
            var entity = _service.Get("");

            Assert.Null(entity.userBo);
            Assert.Null(entity.userDbbo);
        }
    }
}