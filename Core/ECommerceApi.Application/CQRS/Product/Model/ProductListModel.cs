using Core.Persistence.Paging;
using ECommerceApi.Application.CQRS.Product.Queries.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Product.Model
{
    public class ProductListModel : BasePageableModel
    {

        public IList<GetAllProductQueryResponse> Items { get; set; }
    }
}
