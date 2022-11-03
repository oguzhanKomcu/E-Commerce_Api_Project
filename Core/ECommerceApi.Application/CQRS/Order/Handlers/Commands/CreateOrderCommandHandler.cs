using AutoMapper;
using ECommerceApi.Application.CQRS.Order.Commands.Request;
using ECommerceApi.Application.CQRS.Order.Commands.Response;
using ECommerceApi.Application.RepositoriesInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Order.Handlers.Commands
{

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }


        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {


            var model = _mapper.Map<ECommerceApi.Domain.Entities.Order>(request);

            await _orderRepository.Create(model);

            return new CreateOrderCommandResponse
            {
                IsSuccess = true,
                OrderId = model.Id
            };
        }
    }
}
