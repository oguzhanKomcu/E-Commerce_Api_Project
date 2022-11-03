using ECommerceApi.Application.CQRS.Order_Details.Commands.Response;
using ECommerceApi.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Order_Details.Commands.Request
{
    public class CreateOrderDetailCommandRequest : IRequest<CreateOrderDetailCommandResponse>
    {
        public int Order_Id { get; set; }
        public int Product_Id { get; set; }

        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public DateTime CreateDate { get; set; }
        public Status Status { get; set; }
    }
}
