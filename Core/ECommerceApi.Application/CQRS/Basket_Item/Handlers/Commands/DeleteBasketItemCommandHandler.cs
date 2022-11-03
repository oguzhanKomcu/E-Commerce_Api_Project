using ECommerceApi.Application.CQRS.Basket_Item.Commands.Request;
using ECommerceApi.Application.CQRS.Basket_Item.Commands.Response;
using ECommerceApi.Application.RepositoriesInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Basket_Item.Handlers.Command
{

    public class DeleteBasketItemCommandHandler : IRequestHandler<DeleteBasketItemCommandRequest, DeleteBasketItemCommandResponse>
    {
        private readonly IBasketItemRepository _basketItemRepository;

        public DeleteBasketItemCommandHandler(IBasketItemRepository basketItemRepository)
        {
            _basketItemRepository = basketItemRepository;
        }


        public async Task<DeleteBasketItemCommandResponse> Handle(DeleteBasketItemCommandRequest request, CancellationToken cancellationToken)
        {


            var category = await _basketItemRepository.GetDefault(x => x.Id == request.BasketItem_Id);

            category.Status = Domain.Enums.Status.Passive;
            category.DeleteDate = DateTime.Now;

            await _basketItemRepository.Commit();

            return new DeleteBasketItemCommandResponse
            {
                IsSuccess = true,
            };
        }
    }
}
