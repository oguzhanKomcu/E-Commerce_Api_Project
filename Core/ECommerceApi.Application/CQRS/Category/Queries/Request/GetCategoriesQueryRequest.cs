using ECommerceApi.Application.CQRS.Category.Queries.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Category.Queries.Request
{
    public class GetCategoriesQueryRequest : IRequest<List<GetCategoriesQueryResponse>>
    {
    }
}
