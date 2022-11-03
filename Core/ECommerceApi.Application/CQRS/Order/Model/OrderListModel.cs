using Core.Persistence.Paging;
using ECommerceApi.Application.CQRS.Order.Queries.Response;
using ECommerceApi.Application.CQRS.Product.Queries.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Order.Model
{


    public class OrderListModel : BasePageableModel
    {

        public IList<GetByDynamicOrderQueryResponse> Items { get; set; }
    }
}
