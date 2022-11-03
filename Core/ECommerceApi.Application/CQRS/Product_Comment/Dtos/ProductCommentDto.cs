using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Product_Comment.Dtos
{
    public class ProductCommentDto
    {
        public int Id { get; set; }
        public int Product_Id { get; set; }

        public string User_Id { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
        public string UserImage { get; set; }
        public string? CreateDate { get; set; }
    }
}
