using DTRDAL.Context;

namespace DTRDAL.UOW.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DTRContext _context;

        public UnitOfWork(DTRContext context)
        {
            _context = context;
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