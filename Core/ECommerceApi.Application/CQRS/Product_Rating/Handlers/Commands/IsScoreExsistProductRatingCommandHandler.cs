using AutoMapper;
using ECommerceApi.Application.CQRS.Product_Rating.Commands.Request;
using ECommerceApi.Application.CQRS.Product_Rating.Commands.Response;
using ECommerceApi.Application.RepositoriesInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Product_Rating.Handlers.Commands
{

    public class IsRatingExsistProductRatingCommandHandler : IRequestHandler<IsRatingExsistProductRatingCommandRequest, IsRatingExsistProductRatingCommandResponse>
    {
        private readonly IProductRatingRepository _productRatingRepository;
        private readonly IMapper _mapper;

        public IsRatingExsistProductRatingCommandHandler(IProductRatingRepository productRatingRepository, IMapper mapper)
        {
            _productRatingRepository = productRatingRepository;
            _mapper = mapper;
        }


        public async Task<IsRatingExsistProductRatingCommandResponse> Handle(IsRatingExsistProductRatingCommandRequest request, CancellationToken cancellationToken)
        {
            bool isExist = await _productRatingRepository.Any(x => x.User_Id == request.User_Id && x.Product_Id == request.Product_Id);
           
         

            return new IsRatingExsistProductRatingCommandResponse
            {
                IsSuccess = isExist,

            };
        }
    }
}
