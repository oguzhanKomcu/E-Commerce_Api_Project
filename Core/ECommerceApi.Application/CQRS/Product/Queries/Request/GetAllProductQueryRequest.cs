using Core.Application.Requests;
using ECommerceApi.Application.CQRS.Product.Model;
using ECommerceApi.Application.CQRS.Product.Queries.Response;
using MediatR;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Product.Queries.Request
{
    public class GetAllProductQueryRequest : IRequest<ProductListModel>
    {
         public PageRequest PageRequest { get; set; }

    }
}
