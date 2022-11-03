using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Order.Commands.Response
{
    public class CreateOrderCommandResponse
    {
        public bool IsSuccess { get; set; }
        public int OrderId { get; set; }

    }
}
