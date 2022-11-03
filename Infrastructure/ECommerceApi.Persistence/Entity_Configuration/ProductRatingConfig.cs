using ECommerceApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Persistence.Entity_Configuration
{
    public class ProductRatingConfig : BaseEntityConfig<Product_Rating>
    {
        public override void Configure(EntityTypeBuilder<Product_Rating> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User)
            .WithMany(x => x.Product_Ratings)
            .HasForeignKey(x => x.User_Id).IsRequired(false);


            builder.HasOne(x => x.Product)
            .WithMany(x => x.Product_Ratings)
            .HasForeignKey(x => x.Product_Id);


            builder.Property(x => x.Rating)
                .HasPrecision(18, 5)
                .HasConversion<decimal>()
                .IsRequired();


            base.Configure(builder);
        }
    }
}
