using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTRDAL.Context;
using DTRDAL.Entities;

namespace DTRDAL.Repositories.Implementations
{
    class ProjectRepository : IProjectRepository
    {
        private readonly DTRContext _context;

        public ProjectRepository(DTRContext context)
        {
            _context = context;
        }
        public Project Create(Project ent)
        {
            return _context.Projects.Add(ent).Entity;
        }

        public Project Get(int id)
        {
            return _context.Projects.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Project> GetAll()
        {
            return _context.Projects;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
