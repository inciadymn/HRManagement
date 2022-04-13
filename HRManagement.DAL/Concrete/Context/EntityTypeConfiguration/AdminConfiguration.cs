using HRManagement.Model.Entities;
using HRManagement.Model.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.DAL.Concrete.Context.EntityTypeConfiguration
{
    class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {

            builder.HasKey(a => a.ID);
            builder.Property(a => a.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.Password)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(a => a.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.LastName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.PhoneNumber)
                .HasMaxLength(18);

            builder.HasIndex(a => a.Email)
                .IsUnique();

            builder.HasData(new Admin
            {
                ID = 1,
                FirstName = "Gamze",
                LastName = "Altınelli",
                Email = "admin@admin.com",
                Password = "admin",
                UserRole = UserRole.Admin,
                IsActive = true,
                PhoneNumber = "55555555"
            });
        }
    }
}
