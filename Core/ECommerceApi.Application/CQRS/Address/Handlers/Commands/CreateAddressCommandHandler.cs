using AutoMapper;
using ECommerceApi.Application.CQRS.Address.Commands.Request;
using ECommerceApi.Application.CQRS.Address.Commands.Response;
using ECommerceApi.Application.RepositoriesInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Address.Handlers.Commands
{


    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommandRequest, CreateAddressCommandResponse>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public CreateAddressCommandHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }


        public async Task<CreateAddressCommandResponse> Handle(CreateAddressCommandRequest request, CancellationToken cancellationToken)
        {

            var model = _mapper.Map<ECommerceApi.Domain.Entities.Address>(request);

            await _addressRepository.Create(model);
        
            return new CreateAddressCommandResponse
            {
                IsSuccess = true,
                AddressId = model.Id
            };
        }
    }
}
