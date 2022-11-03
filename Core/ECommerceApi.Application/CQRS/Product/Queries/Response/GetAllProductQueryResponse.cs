using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Product.Queries.Response
{
    public class GetAllProductQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string ImagePath { get; set; }
        public int Stock { get; set; }
        public string Category_Name { get; set; }


        public DateTime CreateDate => DateTime.Now;
    }
}
