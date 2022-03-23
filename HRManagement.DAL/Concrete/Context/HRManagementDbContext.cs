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
            optionsBuilder.UseSqlServer("Server=tcp:hrmanagement.database.windows.net,1433;Initial Catalog=HRManagement;Persist Security Info=False;User ID=HrManagement;Password=Giresun2861;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;");
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Permission> Permission { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            
        }
    }
}
