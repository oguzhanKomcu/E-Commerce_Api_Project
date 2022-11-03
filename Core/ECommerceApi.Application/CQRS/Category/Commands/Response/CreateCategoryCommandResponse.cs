using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Category.Commands.Response
{
    public class CreateCategoryCommandResponse
    {
        public bool IsSuccess { get; set; }
        public int CategoryId { get; set; }
    }
}
