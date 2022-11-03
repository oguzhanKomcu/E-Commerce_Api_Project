using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Basket_Item.Commands.Response
{
    public class CreateBasketItemCommandResponse
    {
        public int Basket_Item_Id { get; set; }
        public bool IsSuccess { get; set; }
    }
}
