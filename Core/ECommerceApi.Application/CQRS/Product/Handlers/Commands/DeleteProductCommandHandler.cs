using AutoMapper;
using ECommerceApi.Application.CQRS.Product.Commands.Request;
using ECommerceApi.Application.CQRS.Product.Commands.Response;
using ECommerceApi.Application.RepositoriesInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Product.Handlers.Commands
{

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly IProductRepository _productRepository;


        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;

        }


        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {

            var product = await _productRepository.GetDefault(x => x.Id == request.Id);

            product.Status = Domain.Enums.Status.Passive;
            product.DeleteDate = DateTime.Now;

            await _productRepository.Commit();



            return new DeleteProductCommandResponse
            {
                IsSuccess = true,
                
            };
        }
    }
}
