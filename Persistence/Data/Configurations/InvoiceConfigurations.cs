using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data.Configurations
{
    internal class InvoiceConfigurations : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasOne(O => O.Order)
                   .WithOne(O => O.Invoice)
                   .HasForeignKey<Invoice>(i => i.OrderId);
            builder.Property(i => i.TotalAmount).HasPrecision(18, 2);
        }
    }
}
