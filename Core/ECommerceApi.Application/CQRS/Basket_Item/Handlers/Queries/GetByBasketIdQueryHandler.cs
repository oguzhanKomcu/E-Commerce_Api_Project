using ECommerceApi.Application.CQRS.Basket_Item.Queries.Request;
using ECommerceApi.Application.CQRS.Basket_Item.Queries.Response;
using ECommerceApi.Application.RepositoriesInterface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Basket_Item.Handlers.Queries
{



    public class GetByBasketIdQueryHandler : IRequestHandler<GetByBasketIdQueryRequest, List<GetByBasketIdQueryResponse>>
    {
        private readonly IBasketItemRepository _basketItemRepository;

        public GetByBasketIdQueryHandler(IBasketItemRepository basketItemRepository)
        {
            _basketItemRepository = basketItemRepository;
        }


        public async Task<List<GetByBasketIdQueryResponse>> Handle(GetByBasketIdQueryRequest request, CancellationToken cancellationToken)
        {

            var basketitems = await _basketItemRepository.GetFilteredList(
                selector: x => new GetByBasketIdQueryResponse
                {


                    BasketItemId = x.Id,
                    Product_Name = x.Product.Name,
                    Product_Description = x.Product.Description,
                    Price = x.Product.Price,
                    Product_Image = x.Product.ImagePath,
                    Basket_Id = x.Basket_Id,
                    Quantity = x.Quantity,
                    ProductID = x.ProductID,
                    UnitPrice = x.UnitPrice,

                },
                expression: x => x.Status != Domain.Enums.Status.Passive,
                orderBy: x => x.OrderBy(x => x.CreateDate));





            return basketitems;
        }
    }
}
