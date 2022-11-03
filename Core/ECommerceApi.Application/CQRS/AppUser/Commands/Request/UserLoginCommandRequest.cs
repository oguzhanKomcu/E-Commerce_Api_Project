using ECommerceApi.Application.CQRS.AppUser.Commands.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.AppUser.Commands.Request
{
    public class UserLoginCommandRequest : IRequest<UserLoginCommandResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
