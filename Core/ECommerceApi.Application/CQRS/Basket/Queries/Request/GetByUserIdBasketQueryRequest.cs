using ECommerceApi.Application.CQRS.Basket.Queries.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Basket.Queries.Request
{
    public class GetByUserIdBasketQueryRequest : IRequest<GetByUserIdBasketQueryResponse>
    {
        public string User_Id { get; set; }
    }
}
