using ECommerceApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Persistence.Entity_Configuration
{

    public class BasketConfig : BaseEntityConfig<Basket>
    {
        public override void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.AppUserEmail).IsRequired(false);
            builder.Property(x => x.Subtotal).HasPrecision(18, 5).HasConversion<decimal>().IsRequired();

            builder.HasOne(x => x.AppUser).WithMany(x => x.Baskets).HasForeignKey(x => x.User_Id);



            base.Configure(builder);
        }
    }
}
