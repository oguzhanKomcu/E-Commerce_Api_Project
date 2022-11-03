using ECommerceApi.Application.CQRS.Basket_Item.Queries.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Basket_Item.Queries.Request
{
    public class GetByBasketIdQueryRequest : IRequest<List<GetByBasketIdQueryResponse>>
    {

        public int BasketId { get; set; }
    }
}
