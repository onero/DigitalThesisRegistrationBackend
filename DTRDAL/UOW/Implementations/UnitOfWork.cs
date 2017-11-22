using DTRDAL.Context;
using DTRDAL.Repositories;
using DTRDAL.Repositories.Implementations;

namespace DTRDAL.UOW.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DTRContext _context;

        public IStudentRepository StudentRepository { get; }

        public UnitOfWork(DTRContext context)
        {
            _context = context;
            StudentRepository = new StudentRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Complete()
        {
            _context.SaveChangesAsync();
        }
    }
}