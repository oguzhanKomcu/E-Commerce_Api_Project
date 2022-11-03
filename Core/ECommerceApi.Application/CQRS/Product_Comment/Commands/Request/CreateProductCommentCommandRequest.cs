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
    public class CreateProductCommentCommandRequest : IRequest<CreateProductCommentCommandResponse>
    {
        public int PostId { get; set; }

        public string UserId { get; set; }

        public string Text { get; set; } 
        public DateTime CreateDate => DateTime.Now;
        public Status Status => Status.Active;
    }
}
