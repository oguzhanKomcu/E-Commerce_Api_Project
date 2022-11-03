using ECommerceApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Persistence.Entity_Configuration
{
    public class AppUserConfig : BaseEntityConfig<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserName).IsRequired();
            builder.Property(x => x.First_Name).IsRequired();
            builder.Property(x => x.Last_Name).IsRequired();
            builder.Property(x => x.ImagePath).IsRequired(false);
            base.Configure(builder);
        }
    }
}
