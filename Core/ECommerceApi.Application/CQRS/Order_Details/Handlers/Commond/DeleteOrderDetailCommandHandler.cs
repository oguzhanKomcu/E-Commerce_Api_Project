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

    public class DeleteOrderDetailCommandHandler : IRequestHandler<DeleteOrderDetailCommandRequest, DeleteOrderDetailCommandResponse>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public DeleteOrderDetailCommandHandler(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }


        public async Task<DeleteOrderDetailCommandResponse> Handle(DeleteOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {


            var order_Detail = await _orderDetailRepository.GetDefault(x => x.Id == request.OrderDetailId);

            order_Detail.Status = Domain.Enums.Status.Passive;
            order_Detail.DeleteDate = DateTime.Now;

            await _orderDetailRepository.Commit();

            return new DeleteOrderDetailCommandResponse
            {
                IsSuccess = true,
                Order_Detail_Id = order_Detail.Id
            };

        }
    }

}
