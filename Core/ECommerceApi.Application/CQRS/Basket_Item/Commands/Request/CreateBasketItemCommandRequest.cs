using ECommerceApi.Application.CQRS.Basket_Item.Commands.Response;
using ECommerceApi.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Basket_Item.Commands.Request
{
    public class CreateBasketItemCommandRequest : IRequest<CreateBasketItemCommandResponse>
    {
        public int Basket_Id { get; set; }
        public int ProductID { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public decimal UnitPrice { get; set; }
        public DateTime CreateDate { get; set; }
        public Status Status { get; set; }
    }
}
