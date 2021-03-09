using Microsoft.EntityFrameworkCore;
using Staff.BL.Models;

namespace Staff.BL
{
    public class DataContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=TestDatabase2; Trusted_Connection=True");
        }
    }
}
