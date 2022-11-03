using ECommerceApi.Application.CQRS.Product_Comment.Commands.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.Validation.FluentValidation
{
    public class ProductCommentValidation : AbstractValidator<CreateProductCommentCommandRequest>
    {
        public ProductCommentValidation()
        {
            RuleFor(x => x.Text).MaximumLength(500);
        }

    }
}
