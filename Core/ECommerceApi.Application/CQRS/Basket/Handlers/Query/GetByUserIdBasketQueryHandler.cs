using ECommerceApi.Application.CQRS.Basket.Queries.Request;
using ECommerceApi.Application.CQRS.Basket.Queries.Response;
using ECommerceApi.Application.RepositoriesInterface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Basket.Handlers.Query
{

    public class GetByUserIdBasketQueryHandler : IRequestHandler<GetByUserIdBasketQueryRequest, GetByUserIdBasketQueryResponse>
    {
        private readonly IBasketRepository _basketRepository;

        public GetByUserIdBasketQueryHandler(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }


        public async Task<GetByUserIdBasketQueryResponse> Handle(GetByUserIdBasketQueryRequest request, CancellationToken cancellationToken)
        {

            var basket = await _basketRepository.GetFilteredFirstOrDefault(
              selector: x => new GetByUserIdBasketQueryResponse
              {/*GetByBasketIdBasketItemsQueryResponse*/
                  AppUserEmail = x.AppUserEmail,
                  Subtotal = x.BasketItems.Sum(y => y.Price),
                  User_Id = x.User_Id,
                  Basket_Id = x.Id,
                  BasketItems = x.BasketItems.ToList(),





              },
              expression: x => x.Status != Domain.Enums.Status.Passive && x.User_Id == request.User_Id,
               include: x => x.Include(x => x.BasketItems));





            return basket;
        }



    }

}

