using ECommerceApi.Application.CQRS.Product.Queries.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Product.Queries.Request
{
    public class GetProductByCategoryRequest :  IRequest<List<GetProductByCategoryResponse>>
    {

        public int CategoryId { get; set; }
    }
}
