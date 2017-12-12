using System;
using System.Collections.Generic;
using System.Text;
using DTRDAL.Context;
using DTRDAL.Entities;

namespace DTRDAL.Repositories.Implementations
{
    class UserRepository : IUserRepository
    {
        private readonly DTRContext _context;

        public UserRepository(DTRContext context)
        {
            _context = context;
        }

        public User Create(User ent)
        {
            var result = _context.Users.Add(ent).Entity;
            return result;
        }
        
    }
}
