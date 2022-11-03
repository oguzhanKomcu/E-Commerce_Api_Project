using ECommerceApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Persistence.Entity_Configuration
{
    public class ProductCommentConfig : BaseEntityConfig<Product_Comment>
    {
        public override void Configure(EntityTypeBuilder<Product_Comment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User)
            .WithMany(x => x.Product_Comments)
            .HasForeignKey(x => x.User_Id).IsRequired(false);


            builder.HasOne(x => x.Product)
            .WithMany(x => x.Product_Comments)
            .HasForeignKey(x => x.Product_Id);

            builder.Property(x => x.Text).HasMaxLength(500).IsRequired();





            base.Configure(builder);
        }
    }
}
