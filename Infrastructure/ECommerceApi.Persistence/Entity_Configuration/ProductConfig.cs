using ECommerceApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Persistence.Entity_Configuration
{
    public class ProductConfig : BaseEntityConfig<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.ImagePath).IsRequired();
            builder.Property(x => x.Size).IsRequired();
            builder.Property(x => x.Color).IsRequired();
            builder.Property(x => x.Stock).IsRequired();
            builder.Property(x => x.Price)
                .HasPrecision(18, 5)
                .HasConversion<decimal>()
                .IsRequired();

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.Category_Id);

            base.Configure(builder);
        }
    }
}
