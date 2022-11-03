using ECommerceApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Persistence.Entity_Configuration
{


    public class PaymentConfig : BaseEntityConfig<Payment>
    {
        public override void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(x => x.Id);



            base.Configure(builder);
        }
    }

}
