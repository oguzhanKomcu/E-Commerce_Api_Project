using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Basket_Item.Queries.Response
{
    public class GetByBasketIdQueryResponse
    {
        public int BasketItemId { get; set; }
        public int Basket_Id { get; set; }
        public int ProductID { get; set; }
        public string Product_Name { get; set; }
        public string Product_Description { get; set; }
        public string Product_Image { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
