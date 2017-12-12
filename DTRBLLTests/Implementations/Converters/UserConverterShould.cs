using System;
using System.Collections.Generic;
using System.Text;
using DTRBLL.BusinessObjects;
using DTRDAL.Entities;
using Xunit;

namespace DTRBLLTests.Implementations.Converters
{
    public class UserConverterShould : IConverterTest
    {
        private readonly UserConverterShould _converter;

        private readonly User mockUser = new User { Id = 1, Username = "Test", Salt = new byte[1], PasswordHash = new byte[1], Role = "Administrator"};
        private readonly UserBO mockUserBo = new UserBO { Username = "Test", Role = "Administrator", Password = "Test"};
        private readonly UserDBBO mockUserDbbo = new UserDBBO { Salt = new byte[1], PasswordHash = new byte[1]};


        public UserConverterShould()
        {
            _converter = new UserConverterShould();
        }
        [Fact]
        public void ConvertEntity()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void ConvertBO()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void NotConvertEntity_WithNull()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void NotConvertBO_WithNull()
        {
            throw new NotImplementedException();
        }
    }
}
