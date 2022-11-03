using ECommerceApi.Application.CQRS.Order_Details.Queries.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Order_Details.Queries.Request
{
    public class GetByOrderIdOrderDetailQueryRequest : IRequest<List<GetByOrderIdOrderDetailQueryResponse>>
    {
        public int Order_Id { get; set; }
    }
}
