using System.Collections.Generic;
using System.Linq;
using DTRDAL.Context;
using DTRDAL.Entities;

namespace DTRDAL.Repositories.Implementations
{
    internal class ContractRepository : IContractRepository
    {
        private readonly DTRContext _context;

        public ContractRepository(DTRContext context)
        {
            _context = context;
        }

        public Contract Create(Contract ent)
        {
            return _context.Contracts.Add(ent).Entity;
        }

        public Contract Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Contract Get(int projectId, int groupId, int companyId)
        {
            return _context.Contracts.FirstOrDefault(c =>
                c.GroupId == groupId &&
                c.CompanyId == companyId &&
                c.ProjectId == projectId);
        }

        public IEnumerable<Contract> GetAll()
        {
            return _context.Contracts;
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}