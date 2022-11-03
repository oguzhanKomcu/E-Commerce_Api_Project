using AutoMapper;
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


    public class CreateBasketItemCommandHandler : IRequestHandler<CreateBasketItemCommandRequest, CreateBasketItemCommandResponse>
    {
        private readonly IBasketItemRepository _basketItemRepository;
        private readonly IMapper _mapper;

        public CreateBasketItemCommandHandler(IBasketItemRepository basketItemRepository, IMapper mapper)
        {
            _basketItemRepository = basketItemRepository;
            _mapper = mapper;
        }


        public async Task<CreateBasketItemCommandResponse> Handle(CreateBasketItemCommandRequest request, CancellationToken cancellationToken)
        {

            var result = await _basketItemRepository.Any(x => x.ProductID == request.ProductID);
            var model = _mapper.Map<ECommerceApi.Domain.Entities.BasketItem>(request);
            if (result != true )
            {
                

                await _basketItemRepository.Create(model);
                return new CreateBasketItemCommandResponse
                {
                    IsSuccess = true,
                    Basket_Item_Id = model.Id
                };
            }
            else
            {
                return new CreateBasketItemCommandResponse
                {
                    IsSuccess = false,
                    Basket_Item_Id = model.Id
                };
            }
            

           
        }
    }
}
