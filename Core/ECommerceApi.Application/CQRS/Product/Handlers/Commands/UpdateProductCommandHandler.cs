using AutoMapper;
using ECommerceApi.Application.CQRS.Product.Commands.Request;
using ECommerceApi.Application.CQRS.Product.Commands.Response;
using ECommerceApi.Application.RepositoriesInterface;
using MediatR;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Product.Handlers.Commands
{

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }


        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {

            var model = _mapper.Map<ECommerceApi.Domain.Entities.Product>(request);
            if (request.UploadPath != null)
            {
                using var image = Image.Load(request.UploadPath.OpenReadStream());
                image.Mutate(x => x.Resize(256, 256));
                string guid = Guid.NewGuid().ToString();
                image.Save($"wwwroot/images/products/{guid}.jpg");
                model.ImagePath = $"/images/products/{guid}.jpg";
            }
            await _productRepository.Create(model);
            await _productRepository.Commit();

            return new UpdateProductCommandResponse
            {
                IsSuccess = true,
                ProductId = model.Id
            };
        }
    }
}
