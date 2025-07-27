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
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(c => c.Customer)
                   .WithMany(o => o.Orders)
                   .HasForeignKey(c => c.CustomerId);
            builder.Property(o => o.TotalAmount).HasPrecision(18, 2);

        }
    }
}
