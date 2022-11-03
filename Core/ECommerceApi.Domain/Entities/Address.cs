using ECommerceApi.Domain.Entities.Common;
using ECommerceApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Domain.Entities
{
    public class Address : IBaseEntity
    {
        public int Id { get; set; }
        public string Street { get; set; }


        public string Street2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string Zip { get; set; }

        public string UserID { get; set; }
        public AppUser AppUser { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; }
        public List<Order> Orders { get; set; }

    }
}
