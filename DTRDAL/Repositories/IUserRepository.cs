using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using DTRDAL.Entities;

namespace DTRDAL.Repositories
{
    public interface IUserRepository
    {
        bool Create(User ent);
        User Get(Expression<Func<User, bool>> predicate);
    }
}
