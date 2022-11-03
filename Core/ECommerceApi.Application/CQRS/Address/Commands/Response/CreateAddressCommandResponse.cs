using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Address.Commands.Response
{
    public  class CreateAddressCommandResponse
    {
        public bool IsSuccess { get; set; }
        public int AddressId { get; set; }
    }
}
