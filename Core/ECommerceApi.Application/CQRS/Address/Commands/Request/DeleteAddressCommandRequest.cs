using ECommerceApi.Application.CQRS.Address.Commands.Response;
using ECommerceApi.Application.CQRS.Category.Commands.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Address.Commands.Request
{
    public class DeleteAddressCommandRequest : IRequest<DeleteAddressCommandResponse>
    {
        public int Id { get; set; }
    }
}
