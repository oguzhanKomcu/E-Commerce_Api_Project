using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.AppUser.Commands.Response
{
    public class UserRegisterCommandResponse
    {
        public bool IsSuccess { get; set; }
        public string UserId { get; set; }
    }
}
