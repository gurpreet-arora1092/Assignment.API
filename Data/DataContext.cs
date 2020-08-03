using System;
using Assignment.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }


        public DbSet<Employee> Employees { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Employee>()
                 .HasKey(m => new { m.EmployeeId });
            

        }
    }
}
