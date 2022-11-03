using ECommerceApi.Application.CQRS.Address.Queries.Request;
using ECommerceApi.Application.CQRS.Address.Queries.Response;
using ECommerceApi.Application.RepositoriesInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Address.Handlers.Queries
{

    public class GetUserAddressListQueryHandler : IRequestHandler<GetUserAddressListQueryRequest, List<GetUserAddressListQueryResponse>>
    {
        private readonly IAddressRepository _addressRepository;

        public GetUserAddressListQueryHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }


        public async Task<List<GetUserAddressListQueryResponse>> Handle(GetUserAddressListQueryRequest request, CancellationToken cancellationToken)
        {

            var addresses = await _addressRepository.GetFilteredList(
              selector: x => new GetUserAddressListQueryResponse
              {
                  Id = x.Id,
                  Street = x.Street,
                  Street2 = x.Street2,
                  City = x.City,
                  State = x.State,
                  Country = x.Country,
                  Zip = x.Zip,

              },
              expression: x => x.Status != Domain.Enums.Status.Passive && x.UserID == request.UserID,
              orderBy: x => x.OrderBy(x => x.City)); 

            return addresses;

        }

    }
}
