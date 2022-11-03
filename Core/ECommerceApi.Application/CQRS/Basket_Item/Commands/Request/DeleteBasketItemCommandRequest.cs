using ECommerceApi.Application.CQRS.Basket_Item.Commands.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Basket_Item.Commands.Request
{
    public class DeleteBasketItemCommandRequest : IRequest<DeleteBasketItemCommandResponse>
    {
        public int BasketItem_Id { get; set; }
    }
}
