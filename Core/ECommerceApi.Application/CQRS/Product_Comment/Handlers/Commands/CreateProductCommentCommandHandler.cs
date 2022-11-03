using AutoMapper;
using ECommerceApi.Application.CQRS.Product_Comment.Commands.Request;
using ECommerceApi.Application.CQRS.Product_Comment.Commands.Response;
using ECommerceApi.Application.RepositoriesInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Product_Comment.Handlers.Commands
{

    public class CreateProductCommentCommandHandler : IRequestHandler<CreateProductCommentCommandRequest, CreateProductCommentCommandResponse>
    {
        private readonly IProductCommentRepository _productCommentRepository;
        private readonly IMapper _mapper;

        public CreateProductCommentCommandHandler(IProductCommentRepository productCommentRepository, IMapper mapper)
        {
            _productCommentRepository = productCommentRepository;
            _mapper = mapper;
        }


        public async Task<CreateProductCommentCommandResponse> Handle(CreateProductCommentCommandRequest request, CancellationToken cancellationToken)
        {

            var model = _mapper.Map<ECommerceApi.Domain.Entities.Product_Comment>(request);

            await _productCommentRepository.Create(model);

            return new CreateProductCommentCommandResponse
            {
                IsSuccess = true,
                ProductCommentId = model.Id
            };
        }
    }
}
