using Core.Application.Requests;
using Core.Persistence.Dynamic;
using ECommerceApi.Application.CQRS.Order.Model;
using ECommerceApi.Application.CQRS.Product.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Order.Queries.Request
{


    public class GetListOrderByDynamicQueryRequest : IRequest<OrderListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }
    }

}
