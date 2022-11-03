using ECommerceApi.Domain.Entities.Common;
using ECommerceApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Domain.Entities
{
    public class Product_Comment : IBaseEntity
    {
        public int Id { get; set; }

        public int Product_Id { get; set; }
        public Product Product { get; set; }
        public string User_Id { get; set; }
        public AppUser User { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; }


    }
}
