using AutoMapper;
using Core.Persistence.Paging;
using ECommerceApi.Application.CQRS.Order.Model;
using ECommerceApi.Application.CQRS.Order.Queries.Request;
using ECommerceApi.Application.CQRS.Order.Queries.Response;
using ECommerceApi.Application.CQRS.Product.Model;
using ECommerceApi.Application.CQRS.Product.Queries.Request;
using ECommerceApi.Application.RepositoriesInterface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Order.Handlers.Queries
{



    public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQueryRequest, OrderListModel>
    {

        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderListQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }


        public async Task<OrderListModel> Handle(GetOrderListQueryRequest request, CancellationToken cancellationToken)
        {



            IPaginate<ECommerceApi.Domain.Entities.Order> models = await _orderRepository.GetListAsync(include:
                                             m => m.Include(c => c.AppUser),
                                             index: request.PageRequest.Page,
                                             size: request.PageRequest.PageSize
                                             );
            //dataModel
            OrderListModel mappedModels = _mapper.Map<OrderListModel>(models);
            return mappedModels;

        }
    }



}
