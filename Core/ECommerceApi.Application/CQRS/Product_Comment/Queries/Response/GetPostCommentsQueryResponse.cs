using ECommerceApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Product_Comment.Queries.Response
{
    public class GetPostCommentsQueryResponse
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string UserName{ get; set; }
        public string User_Id { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public Status Status { get; set; }
    }
}
