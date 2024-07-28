using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LAP.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=TestData;Integrated Security=True;TrustServerCertificate=True");
        }
    }
    
}
