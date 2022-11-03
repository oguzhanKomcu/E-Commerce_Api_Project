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
    public class CreateOrderCommandRequest : IRequest<CreateOrderCommandResponse>
    {
        public string User_Id { get; set; }
        public int Amount { get; set; }
        public string Shipping_Address { get; set; }
        public int AddressID { get; set; }
        public DateTime CreateDate { get; set; }
        public Status Status { get; set; }
    }
}
