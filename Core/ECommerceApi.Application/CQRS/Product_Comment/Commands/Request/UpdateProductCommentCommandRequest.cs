using ECommerceApi.Application.CQRS.Product_Comment.Commands.Response;
using ECommerceApi.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Product_Comment.Commands.Request
{
    public class UpdateProductCommentCommandRequest : IRequest<UpdateProductCommentCommandResponse>
    {
        public int Id { get; set; }

        public int Product_Id { get; set; }
        public string User_Id { get; set; }
        public string Text { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Status Status { get; set; }



    }
}
