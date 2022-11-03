using ECommerceApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Order_Details.Queries.Response
{
    public class GetByOrderIdOrderDetailQueryResponse
    {
        public int Id { get; set; }
        public int Order_Id { get; set; }
        public string Product_Name { get; set; }
        public string Product_Description { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public string SKU { get; set; }

        public string ImagePath { get; set; }


        public int Quantity { get; set; }

        public DateTime CreateDate { get; set; }
        public Status Status { get; set; }
    }
}
