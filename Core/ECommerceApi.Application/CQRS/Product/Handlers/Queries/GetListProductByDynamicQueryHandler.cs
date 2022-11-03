using AutoMapper;
using Core.Persistence.Paging;
using ECommerceApi.Application.CQRS.Product.Model;
using ECommerceApi.Application.CQRS.Product.Queries.Request;
using ECommerceApi.Application.CQRS.Product.Queries.Response;
using ECommerceApi.Application.RepositoriesInterface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Product.Handlers.Queries
{


    public class GetListProductByDynamicQueryHandler : IRequestHandler<GetListProductByDynamicQueryRequest, ProductListModel>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetListProductByDynamicQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }


        public async Task<ProductListModel> Handle(GetListProductByDynamicQueryRequest request, CancellationToken cancellationToken)
        {


            //repositorymizdeki dynamic methodunu kullandık..
            IPaginate<Domain.Entities.Product> models = await _productRepository.GetListByDynamicAsync(request.Dynamic, include:
                                          m => m.Include(c => c.Category),
                                          index: request.PageRequest.Page,
                                          size: request.PageRequest.PageSize
                                          );
            //dataModel
            ProductListModel mappedModels = _mapper.Map<ProductListModel>(models);
            return mappedModels;




        }
    }
}
