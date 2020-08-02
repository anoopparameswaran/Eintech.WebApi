using Eintech.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eintech.Data
{
    public class EintechDbContext : DbContext
    {
        public EintechDbContext(DbContextOptions<EintechDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public DbSet<Person> People { get; set; }
    }
}
