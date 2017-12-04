using System.Collections.Generic;
using System.Linq;
using DTRDAL.Context;
using DTRDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DTRDAL.Repositories.Implementations
{
    public class GroupRepository : IGroupRepository
    {
        private readonly DTRContext _context;

        public GroupRepository(DTRContext context)
        {
            _context = context;
        }

        public Group Create(Group ent)
        {
            return _context.Groups.Add(ent).Entity;
        }

        public Group Get(int id)
        {
            return _context.Groups.Include(g => g.Students).FirstOrDefault(g => g.Id == id);
        }

        public Group Get(string contactEmail)
        {
            return _context.Groups
                .Include(g => g.Students)
                .FirstOrDefault(g => g.ContactEmail.Equals(contactEmail));
        }

        public IEnumerable<Group> GetAll()
        {
            return _context.Groups.Include(g => g.Students);
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}