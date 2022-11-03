using ECommerceApi.Application.CQRS.Order_Details.Commands.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Order_Details.Commands.Request
{
    public class DeleteOrderDetailCommandRequest : IRequest<DeleteOrderDetailCommandResponse>
    {
        public int OrderDetailId { get; set; }
    }
}
