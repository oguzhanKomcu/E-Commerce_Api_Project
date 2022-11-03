using ECommerceApi.Application.CQRS.Address.Queries.Response;
using ECommerceApi.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Address.Queries.Request
{

    public class GetUserAddressListQueryRequest : IRequest<List<GetUserAddressListQueryResponse>>
    {


        public string UserID { get; set; }

    }
}
