using ECommerceApi.Application.CQRS.Product_Comment.Queries.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Product_Comment.Queries.Request
{
    public class GetPostCommentsQueryRequest : IRequest<List<GetPostCommentsQueryResponse>>
    {
        public int PostId { get; set; }
    }
}
