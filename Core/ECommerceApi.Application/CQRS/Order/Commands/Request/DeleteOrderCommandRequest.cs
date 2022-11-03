using ECommerceApi.Application.CQRS.Order.Commands.Response;
using ECommerceApi.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Order.Commands.Request
{

    public class DeleteOrderCommandRequest : IRequest<DeleteOrderCommandResponse>
    {
        public int Id { get; set; }

    }
}
