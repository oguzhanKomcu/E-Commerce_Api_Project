using ECommerceApi.Application.CQRS.Category.Queries.Request;
using ECommerceApi.Application.CQRS.Category.Queries.Response;
using ECommerceApi.Application.CQRS.Order_Details.Queries.Request;
using ECommerceApi.Application.CQRS.Order_Details.Queries.Response;
using ECommerceApi.Application.RepositoriesInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Order_Details.Handlers.Query
{

    public class GetByOrderIdOrderDetailQueryHandler : IRequestHandler<GetByOrderIdOrderDetailQueryRequest, List<GetByOrderIdOrderDetailQueryResponse>>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public GetByOrderIdOrderDetailQueryHandler(IOrderDetailRepository categoryRepository)
        {
            _orderDetailRepository = categoryRepository;
        }


        public async Task<List<GetByOrderIdOrderDetailQueryResponse>> Handle(GetByOrderIdOrderDetailQueryRequest request, CancellationToken cancellationToken)
        {

            var orderDetails = await _orderDetailRepository.GetFilteredList(
              selector: x => new GetByOrderIdOrderDetailQueryResponse
              {
                  Id = x.Id,
                  Product_Name = x.Product.Name,
                 Product_Description = x.Product.Description,
                 ImagePath = x.Product.ImagePath,
                 Price = x.Product.Price,
                 Color = x.Product.Color,
                 SKU = x.Product.SKU,
                 Quantity = x.Quantity
              },
              expression: x => x.Status != Domain.Enums.Status.Passive && x.Order_Id == request.Order_Id,
              orderBy: x => x.OrderBy(x => x.CreateDate));

            return orderDetails;

        }
    }
}
