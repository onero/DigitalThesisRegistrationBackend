using System;
using System.Collections.Generic;
using System.Text;
using DTRBLL.BusinessObjects;
using DTRDAL.Entities;

namespace DTRBLL.Converters.Implementations
{
    class UserConverter
    {
        public User Convert(UserBO userBo, UserDBBO userDbbo)
        {
            return new User
            {
                PasswordHash = userDbbo.PasswordHash,
                Salt = userDbbo.Salt,
                Username = userBo.Username,
                Role = userBo.Role
            };
        }
    }
}
