using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTRDAL.Context;
using DTRDAL.Entities;

namespace DTRDAL.Repositories.Implementations
{
    class CompanyRepository : ICompanyRepository
    {
        private readonly DTRContext _context;

        public CompanyRepository(DTRContext context)
        {
            _context = context;
        }

        public Company Create(Company ent)
        {
            return _context.Companies.Add(ent).Entity;
        }

        public Company Get(int id)
        {
            return _context.Companies.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Company> GetAll()
        {
            return _context.Companies;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
