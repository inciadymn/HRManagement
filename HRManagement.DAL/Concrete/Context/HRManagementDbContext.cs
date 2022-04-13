using HRManagement.Model.Entities;
using Microsoft.EntityFrameworkCore;
using HRManagement.DAL.Concrete.Context.EntityTypeConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.DAL.Concrete.Context
{
    class HRManagementDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=HRManagement;uid=sa;pwd=as");
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<Advance> Advances { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new AdvanceConfiguration());
            modelBuilder.ApplyConfiguration(new AdminConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
        }
    }
}
