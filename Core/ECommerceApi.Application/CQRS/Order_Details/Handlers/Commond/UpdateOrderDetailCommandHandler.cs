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

    public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommandRequest, UpdateOrderDetailCommandResponse>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;

        public UpdateOrderDetailCommandHandler(IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }


        public async Task<UpdateOrderDetailCommandResponse> Handle(UpdateOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {

            var model = _mapper.Map<ECommerceApi.Domain.Entities.Order_Detail>(request);

             _orderDetailRepository.Update(model);
            await _orderDetailRepository.Commit();

            return new UpdateOrderDetailCommandResponse
            {
                IsSuccess = true,
                Order_Detail_Id = model.Id
            };
        }
    }
}
