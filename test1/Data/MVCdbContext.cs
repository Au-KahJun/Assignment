using Microsoft.EntityFrameworkCore;
using test1.Models.Domain;

namespace test1.Data
{
    public class MVCdbSContext : DbContext
    {
        public MVCdbSContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
