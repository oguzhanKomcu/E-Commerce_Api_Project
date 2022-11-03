using ECommerceApi.Application.CQRS.Product.Queries.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Product.Queries.Request
{
    public class GetProductByCategoryQueryRequest : IRequest<GetByIdProductQueryResponse>
    {
        public int Id { get; set; }
    }
}
