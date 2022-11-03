using ECommerceApi.Application.CQRS.AppUser.Queries.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.AppUser.Queries.Request
{
    public class GetUsersQueryRequest : IRequest<List<GetUsersQueryResponse>>
    {
    }
}
