using AutoMapper;
using ECommerceApi.Application.CQRS.Order_Details.Commands.Request;
using ECommerceApi.Application.CQRS.Order_Details.Commands.Response;
using ECommerceApi.Application.RepositoriesInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Order_Details.Handlers.Commond
{

    public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommandRequest, CreateOrderDetailCommandResponse>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;

        public CreateOrderDetailCommandHandler(IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }


        public async Task<CreateOrderDetailCommandResponse> Handle(CreateOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {

            var model = _mapper.Map<ECommerceApi.Domain.Entities.Order_Detail>(request);

            await _orderDetailRepository.Create(model);

            return new CreateOrderDetailCommandResponse
            {
                IsSuccess = true,
                Order_Detail_Id = model.Id
            };
        }
    }

}
