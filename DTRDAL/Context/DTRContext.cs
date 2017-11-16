using Microsoft.EntityFrameworkCore;

namespace DTRDAL.Context
{
    public class DTRContext : DbContext
    {
        public DTRContext(DbContextOptions<DTRContext> options) : base(options)
        {
            //Ensure DB states
            //Comment deleted back in when updating DB
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}