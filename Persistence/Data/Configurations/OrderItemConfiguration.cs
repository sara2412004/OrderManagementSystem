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
    internal class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasOne(O => O.Order)
                   .WithMany(i => i.OrderItems)
                   .HasForeignKey(O => O.OrderId);

            builder.HasOne(P => P.Product)
                   .WithMany(i => i.OrderItems)
                   .HasForeignKey(P => P.ProductId);

            builder.Property(oi => oi.UnitPrice).HasPrecision(18, 2);
            builder.Property(oi => oi.Discount).HasPrecision(18, 2);
        }
    }
}
