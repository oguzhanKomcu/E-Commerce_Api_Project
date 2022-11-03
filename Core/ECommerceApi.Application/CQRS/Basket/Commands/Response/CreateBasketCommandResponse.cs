using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Basket.Commands.Response
{
    public class CreateBasketCommandResponse
    {
        public int Basket_Id { get; set; }
        public bool IsSuccess { get; set; }

    }
}
