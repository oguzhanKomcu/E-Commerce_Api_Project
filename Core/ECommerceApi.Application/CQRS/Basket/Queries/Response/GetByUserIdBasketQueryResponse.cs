using ECommerceApi.Domain.Enums;
using ECommerceApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Basket.Queries.Response
{
    public class GetByUserIdBasketQueryResponse
    {
        public decimal Subtotal { get; set; }
        public string User_Id { get; set; }
        public int Basket_Id { get; set; }
        public List<BasketItem> BasketItems { get; set; }
        public string AppUserEmail { get; set; }


    }
}
