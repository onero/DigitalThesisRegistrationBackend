using System;
using System.Collections.Generic;
using System.Text;
using DTRDAL.Context;
using DTRDAL.Repositories;
using DTRDAL.Repositories.Implementations;
using DTRDALTests.implementations;

namespace DTRDALTests.Implementations
{
    class CompanyRepositoryShould : IRepositoryTest
    {
        private readonly DTRContext _context;
        private readonly CompanyRepository _repository;

        public CompanyRepositoryShould()
        {
            _context = TestContext.Context;
            _repository = new CompanyRepository(_context);
        }

        public void CreateOne()
        {
            throw new NotImplementedException();
        }

        public void GetOneByExistingId()
        {
            throw new NotImplementedException();
        }

        public void NotGetOneByNonExistingId()
        {
            throw new NotImplementedException();
        }

        public void GetAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteByExistingId()
        {
            throw new NotImplementedException();
        }

        public void NotDeleteByNonExistingId()
        {
            throw new NotImplementedException();
        }
    }
}
