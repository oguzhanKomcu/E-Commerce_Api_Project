using ECommerceApi.Application.CQRS.Basket.Commands.Response;
using ECommerceApi.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Basket.Commands.Request
{
    public class CreateBasketCommandRequest : IRequest<CreateBasketCommandResponse>
    {
        public string User_Id { get; set; }
  
        public decimal Subtotal { get; set; }
        public string AppUserEmail { get; set; }

        public DateTime CreateDate { get; set; }

        public Status Status { get; set; }
    }
}
