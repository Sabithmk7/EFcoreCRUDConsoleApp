using EfcoreP1Employee.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EfcoreP1Employee
{
    public class EmloyeeDbContext:DbContext
    {
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Departments> Departments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source = localhost\\SQLEXPRESS; database = store; integrated security = SSPI;TrustServerCertificate=True")
            .LogTo(Console.WriteLine, LogLevel.Information);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employees>()
                .HasOne(e => e.Departments)
                .WithMany(e => e.Employees)
                .HasForeignKey(e => e.DepartmentId);
            modelBuilder.Entity<Departments>()
                .HasKey(d => d.DepartmentId);
        }
    }
}
