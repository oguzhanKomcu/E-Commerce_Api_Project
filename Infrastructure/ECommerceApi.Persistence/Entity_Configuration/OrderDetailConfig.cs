using ECommerceApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Persistence.Entity_Configuration
{
    public class OrderDetailConfig : BaseEntityConfig<Order_Detail>
    {
        public override void Configure(EntityTypeBuilder<Order_Detail> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.Price)
                .HasPrecision(18, 5)
                .HasConversion<decimal>()
                .IsRequired();

            builder.HasOne(x => x.Product)
                .WithMany(x => x.Order_Details)
                .HasForeignKey(x => x.Product_Id);


            builder.HasOne(x => x.Order)
                .WithMany(x => x.Order_Details)
                .HasForeignKey(x => x.Order_Id);

            base.Configure(builder);
        }
    }
}
