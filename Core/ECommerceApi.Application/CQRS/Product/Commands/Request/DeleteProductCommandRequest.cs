using System;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApi.Application.CQRS.Product.Commands.Response;

namespace ECommerceApi.Application.CQRS.Product.Commands.Request
{

    public class DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
    {
        public int Id { get; set; }
    }
}
