using ECommerceApi.Application.CQRS.Basket.Commands.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Basket.Commands.Request
{
    public  class DeleteBasketCommandRequest : IRequest<DeleteBasketCommandResponse>
    {
        public int Id { get; set; }
    }
}
