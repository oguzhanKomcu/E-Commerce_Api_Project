using AutoMapper;
using ECommerceApi.Application.CQRS.Category.Commands.Request;
using ECommerceApi.Application.CQRS.Category.Commands.Response;
using ECommerceApi.Application.RepositoriesInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Category.Handlers.Commands
{


    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }


        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {

            var model = _mapper.Map<ECommerceApi.Domain.Entities.Category>(request);

            await _categoryRepository.Create(model);

            return new CreateCategoryCommandResponse
            {
                IsSuccess = true,
                CategoryId = model.Id
            };
        }
    }


}
