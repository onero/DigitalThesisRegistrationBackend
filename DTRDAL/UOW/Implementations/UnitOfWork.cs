using DTRDAL.Context;
using DTRDAL.Repositories;
using DTRDAL.Repositories.Implementations;

namespace DTRDAL.UOW.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DTRContext _context;

        public IStudentRepository StudentRepository { get; }
        public IGroupRepository GroupRepository { get; }
        public IProjectRepository ProjectRepository { get; }
        public IContractRepository ContractRepository { get; }
        public IAppendixRepository AppendixRepository { get; }
        public ICompanyRepository CompanyRepository { get; }
        public ISupervisorRepository SupervisorRepository { get;  }

        public UnitOfWork(DTRContext context)
        {
            _context = context;
            StudentRepository = new StudentRepository(_context);
            GroupRepository = new GroupRepository(_context);
            CompanyRepository = new CompanyRepository(_context);
            SupervisorRepository = new SupervisorRepository(_context);
            ProjectRepository = new ProjectRepository(_context);
            ContractRepository = new ContractRepository(_context);
            AppendixRepository = new AppendixRepository();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}