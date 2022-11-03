using AutoMapper;
using ECommerceApi.Application.CQRS.Basket.Commands.Request;
using ECommerceApi.Application.CQRS.Basket.Commands.Response;
using ECommerceApi.Application.RepositoriesInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Basket.Handlers.Command
{

    public class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommandRequest, CreateBasketCommandResponse>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public CreateBasketCommandHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }


        public async Task<CreateBasketCommandResponse> Handle(CreateBasketCommandRequest request, CancellationToken cancellationToken)
        {

            var model = _mapper.Map<ECommerceApi.Domain.Entities.Basket>(request);

            await _basketRepository.Create(model);

            return new CreateBasketCommandResponse
            {
                IsSuccess = true,
                Basket_Id = model.Id
            };
        }
    }

}
