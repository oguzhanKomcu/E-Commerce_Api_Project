using AutoMapper;
using ECommerceApi.Application.CQRS.Category.Queries.Request;
using ECommerceApi.Application.CQRS.Category.Queries.Response;
using ECommerceApi.Application.RepositoriesInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Category.Handlers.Queries
{


    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQueryRequest, List<GetCategoriesQueryResponse>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoriesQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        public async Task<List<GetCategoriesQueryResponse>> Handle(GetCategoriesQueryRequest request, CancellationToken cancellationToken)
        {

              var categories = await _categoryRepository.GetFilteredList(
                selector: x => new GetCategoriesQueryResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                },
                expression: x => x.Status != Domain.Enums.Status.Passive,
                orderBy: x => x.OrderBy(x => x.Name));

            return categories;

        }
    }
}
