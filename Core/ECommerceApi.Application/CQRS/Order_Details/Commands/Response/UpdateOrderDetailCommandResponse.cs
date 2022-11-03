using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Order_Details.Commands.Response
{
    public class UpdateOrderDetailCommandResponse
    {
        public bool IsSuccess { get; set; }

        public int Order_Detail_Id { get; set; }
    }
}
