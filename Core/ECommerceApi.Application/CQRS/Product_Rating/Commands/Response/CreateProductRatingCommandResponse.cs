using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Product_Rating.Commands.Response
{
    public class CreateProductRatingCommandResponse
    {
        public int ProductId { get; set; }
        public string UserId { get; set; }
        public bool IsSuccess { get; set; }
    }
}
