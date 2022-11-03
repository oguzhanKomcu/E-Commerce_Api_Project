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


    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommandRequest, DeleteAddressCommandResponse>
    {
        private readonly IAddressRepository _addressRepository;

        public DeleteAddressCommandHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }


        public async Task<DeleteAddressCommandResponse> Handle(DeleteAddressCommandRequest request, CancellationToken cancellationToken)
        {


            var category = await _addressRepository.GetDefault(x => x.Id == request.Id);

            category.Status = Domain.Enums.Status.Passive;
            category.DeleteDate = DateTime.Now;

            await _addressRepository.Commit();

            return new DeleteAddressCommandResponse
            {
                IsSuccess = true,
            };
        }
    }
}
