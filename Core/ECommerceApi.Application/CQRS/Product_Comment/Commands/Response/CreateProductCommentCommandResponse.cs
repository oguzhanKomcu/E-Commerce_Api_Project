using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Product_Comment.Commands.Response
{
    public class CreateProductCommentCommandResponse
    {

        public int ProductCommentId { get; set; }
        public bool IsSuccess { get; set; }

    }
}
