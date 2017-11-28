using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTRDAL.Context;
using DTRDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DTRDAL.Repositories.Implementations
{
    class SupervisorRepository : ISupervisorRepository
    {
        private readonly DTRContext _context;

        public SupervisorRepository(DTRContext context)
        {
            _context = context;
        }

        public Supervisor Create(Supervisor ent)
        {
            return _context.Supervisors.Add(ent).Entity;
        }

        public Supervisor Get(int id)
        {
            return _context.Supervisors.Include(s => s.WantedProjects).Include(s => s.AssignedProjects).FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Supervisor> GetAll()
        {
            return _context.Supervisors.Include(s => s.WantedProjects).Include(s => s.AssignedProjects);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
