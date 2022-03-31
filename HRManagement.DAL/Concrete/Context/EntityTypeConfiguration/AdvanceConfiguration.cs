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
    public class AdvanceConfiguration: IEntityTypeConfiguration<Advance>
    {
        public void Configure(EntityTypeBuilder<Advance> builder)
        {
            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID)
                .UseIdentityColumn();

            builder.Property(a => a.RequestDate)
                   .IsRequired();

            builder.Property(a => a.AdvanceType)
                  .IsRequired();

            builder.Property(a => a.Price)
                   .IsRequired();

            builder.Property(a => a.Description)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(a => a.PermitStatus)
                   .IsRequired();

            builder.HasOne(a => a.Employee)
                .WithMany(a => a.Advances)
                .HasForeignKey(a => a.EmployeeID);
        }
    }
}
