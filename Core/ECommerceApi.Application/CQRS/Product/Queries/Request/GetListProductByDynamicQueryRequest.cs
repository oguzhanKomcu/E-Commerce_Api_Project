using Core.Application.Requests;
using Core.Persistence.Dynamic;
using ECommerceApi.Application.CQRS.Product.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Product.Queries.Request
{
    public class GetListProductByDynamicQueryRequest : IRequest<ProductListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }
    }
}
