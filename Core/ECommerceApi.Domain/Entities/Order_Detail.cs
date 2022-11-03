﻿using ECommerceApi.Domain.Entities.Common;
using ECommerceApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Domain.Entities
{
    public class Order_Detail : IBaseEntity
    {
        public int Id { get; set; }
        public int Order_Id { get; set; }
        public Order Order { get; set; }
        public int Product_Id { get; set; }
        public Product Product { get; set; }

        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; }
    }
}
