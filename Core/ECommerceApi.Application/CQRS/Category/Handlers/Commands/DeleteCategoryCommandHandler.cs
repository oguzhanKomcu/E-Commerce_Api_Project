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


    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, DeleteCategoryCommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {


            var category = await _categoryRepository.GetDefault(x => x.Id == request.Id);

            category.Status = Domain.Enums.Status.Passive;
            category.DeleteDate = DateTime.Now;

            await _categoryRepository.Commit();

            return new DeleteCategoryCommandResponse
            {
                IsSuccess = true,
            };
        }
    }



}
