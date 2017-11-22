using System.Collections.Generic;
using DTRDAL.Context;
using DTRDAL.Entities;

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
            throw new System.NotImplementedException();
        }

        public Group Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Group> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}