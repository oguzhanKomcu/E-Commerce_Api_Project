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

    public class DeleteBasketCommandHandler : IRequestHandler<DeleteBasketCommandRequest, DeleteBasketCommandResponse>
    {
        private readonly IBasketRepository _basketRepository;

        public DeleteBasketCommandHandler(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }



        public async Task<DeleteBasketCommandResponse> Handle(DeleteBasketCommandRequest request, CancellationToken cancellationToken)
        {


            var category = await _basketRepository.GetDefault(x => x.Id == request.Id);

            category.Status = Domain.Enums.Status.Passive;
            category.DeleteDate = DateTime.Now;

            await _basketRepository.Commit();

            return new DeleteBasketCommandResponse
            {
                IsSuccess = true,
            };
        }
    }
}
