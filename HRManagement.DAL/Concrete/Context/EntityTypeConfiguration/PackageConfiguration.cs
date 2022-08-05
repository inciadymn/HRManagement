using HRManagement.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.DAL.Concrete.Context.EntityTypeConfiguration
{
    public class PackageConfiguration : IEntityTypeConfiguration<Package>
    {
        public void Configure(EntityTypeBuilder<Package> builder)
        {
            builder.HasKey(a => a.ID);

            builder.Property(a => a.Name)
            .HasMaxLength(50);

            builder.Property(a => a.Price)
            .IsRequired();

            builder.Property(a => a.StartDate).HasColumnType("Date");
            builder.Property(a => a.EndDate).HasColumnType("Date");

            builder.Property(a => a.ImageUrl).HasMaxLength(100).IsRequired();
            builder.Property(a => a.UserNumber).IsRequired();

            builder.Property(a => a.Duration).IsRequired();

            builder.Property(a => a.IsActive).IsRequired();

            

        }
    }
}
