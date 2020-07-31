using Eintech.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eintech.Data
{
    public class EintechDbContext : DbContext
    {
        public EintechDbContext(DbContextOptions<EintechDbContext> options) : base(options)
        {

        }
        public DbSet<Person> People { get; set; }
    }
}
