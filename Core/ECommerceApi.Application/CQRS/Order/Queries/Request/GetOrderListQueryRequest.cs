using Core.Application.Requests;
using ECommerceApi.Application.CQRS.Order.Model;
using ECommerceApi.Application.CQRS.Order.Queries.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Order.Queries.Request
{
    public class GetOrderListQueryRequest : IRequest<OrderListModel>
    {
        public PageRequest PageRequest { get; set; }
    }
}
