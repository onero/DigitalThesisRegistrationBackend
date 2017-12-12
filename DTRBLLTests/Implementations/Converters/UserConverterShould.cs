using System;
using System.Collections.Generic;
using System.Text;
using DTRBLL.BusinessObjects;
using DTRBLL.Converters.Implementations;
using DTRDAL.Entities;
using Xunit;

namespace DTRBLLTests.Implementations.Converters
{
    public class UserConverterShould : IConverterTest
    {
        private readonly UserConverter _converter;

        private readonly User mockUser = new User { Id = 1, Username = "Test", Salt = new byte[1], PasswordHash = new byte[1], Role = "Administrator"};
        private readonly UserBO mockUserBo = new UserBO { Username = "Test", Role = "Administrator", Password = "Test"};
        private readonly UserDBBO mockUserDbbo = new UserDBBO { Salt = new byte[1], PasswordHash = new byte[1]};


        public UserConverterShould()
        {
            _converter = new UserConverter();
        }
        [Fact]
        public void ConvertEntity()
        {
            var entity = _converter.Convert(mockUserBo, mockUserDbbo);
            Assert.Contains(entity.Username, mockUserBo.Username);
        }

        [Fact]
        public void ConvertBO()
        {
            var entity = _converter.Convert(mockUser);
            Assert.Contains(entity.userBo.Username, mockUser.Username);
        }

        [Fact]
        public void NotConvertEntity_WithNull()
        {
            User nullEntity = null;
            var entity = _converter.Convert(null);
            Assert.Null(entity.userBo);
            Assert.Null(entity.userDbbo);
        }

        [Fact]
        public void NotConvertBO_WithNull()
        {
            UserBO nullUserBO = null;
            UserDBBO nullUserDBBO = null;
            var entity = _converter.Convert(nullUserBO, nullUserDBBO);
            Assert.Null(entity);
        }
    }
}
