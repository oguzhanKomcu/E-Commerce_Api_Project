using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.AppUser.Commands.Response
{
    public class UserLoginCommandResponse
    {
        public bool IsSuccess { get; set; }
        public string UserName { get; set; }
    }
}
