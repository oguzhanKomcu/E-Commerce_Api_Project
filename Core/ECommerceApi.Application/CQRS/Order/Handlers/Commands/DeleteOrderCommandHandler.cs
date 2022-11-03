using ECommerceApi.Application.CQRS.Order.Commands.Request;
using ECommerceApi.Application.CQRS.Order.Commands.Response;
using ECommerceApi.Application.CQRS.Product.Commands.Request;
using ECommerceApi.Application.CQRS.Product.Commands.Response;
using ECommerceApi.Application.RepositoriesInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Order.Handlers.Commands
{

    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommandRequest, DeleteOrderCommandResponse>
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }


        public async Task<DeleteOrderCommandResponse> Handle(DeleteOrderCommandRequest request, CancellationToken cancellationToken)
        {

            var product = await _orderRepository.GetDefault(x => x.Id == request.Id);

            product.Status = Domain.Enums.Status.Passive;
            product.DeleteDate = DateTime.Now;

            await _orderRepository.Commit();



            return new DeleteOrderCommandResponse
            {
                IsSuccess = true,

            };
        }
    }


}
