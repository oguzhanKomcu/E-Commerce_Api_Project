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
    public class UpdateOrderDetailCommandRequest : IRequest<UpdateOrderDetailCommandResponse>
    {
        public int Id { get; set; }
        public int Order_Id { get; set; }
        public int Product_Id { get; set; }

        public int Quantity { get; set; }

        public DateTime UpdateDate{ get; set; }
        public Status Status { get; set; }
    }
}
