using ECommerceApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Order.Queries.Response
{
    public class GetByDynamicOrderQueryResponse
    {
        public int Id { get; set; }
        public string User_Id { get; set; }
        public int Amount { get; set; }
        public string Shipping_Address { get; set; }
        public int AddressID { get; set; }
        public DateTime CreateDate { get; set; }
        public Status Status { get; set; }
    }
}
