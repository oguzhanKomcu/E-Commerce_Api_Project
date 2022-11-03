using ECommerceApi.Application.CQRS.AppUser.Commands.Request;
using ECommerceApi.Application.CQRS.AppUser.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.Validation.FluentValidation
{
    public class LoginValidation : AbstractValidator<UserLoginCommandRequest>
    {
        public LoginValidation()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Enter a user name");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Enter a password");
        }





    }
}
