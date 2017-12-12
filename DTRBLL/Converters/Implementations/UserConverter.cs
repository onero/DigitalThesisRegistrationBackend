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
            if (userBo == null || userDbbo == null) return null;
            return new User
            {
                PasswordHash = userDbbo.PasswordHash,
                Salt = userDbbo.Salt,
                Username = userBo.Username,
                Role = userBo.Role
            };
        }

        public (UserBO userBo, UserDBBO userDbbo) Convert(User user)
        {
            if (user == null) return (null, null);
            return (
                new UserBO
                {
                    Username = user.Username,
                    Role = user.Role
                },
                new UserDBBO
                {
                    Salt = user.Salt,
                    PasswordHash = user.PasswordHash
                });
        }
    }
}
