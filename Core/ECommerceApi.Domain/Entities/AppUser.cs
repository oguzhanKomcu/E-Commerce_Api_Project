using ECommerceApi.Domain.Entities.Common;
using ECommerceApi.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Domain.Entities
{
    public class AppUser : IdentityUser, IBaseEntity
    {
        public string ImagePath { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; }
        public List<Order> Orders { get; set; }
        public List<Product_Comment> Product_Comments { get; set; }
        public List<Product_Rating> Product_Ratings { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Basket> Baskets { get; set; }
    }
}
