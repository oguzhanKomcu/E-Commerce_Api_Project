using ECommerceApi.Application.CQRS.Product_Comment.Queries.Request;
using ECommerceApi.Application.CQRS.Product_Comment.Queries.Response;
using ECommerceApi.Application.RepositoriesInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Product_Comment.Handlers.Queries
{

    public class GetPostCommentsQueryHandler : IRequestHandler<GetPostCommentsQueryRequest, List<GetPostCommentsQueryResponse>>
    {
        private readonly IProductCommentRepository _productCommentRepository;

        public GetPostCommentsQueryHandler(IProductCommentRepository productCommentRepository)
        {
            _productCommentRepository = productCommentRepository;
        }



        public async Task<List<GetPostCommentsQueryResponse>> Handle(GetPostCommentsQueryRequest request, CancellationToken cancellationToken)
        {

            var comments = await _productCommentRepository.GetFilteredList(
              selector: x => new GetPostCommentsQueryResponse
              {
                  Id = x.Id,
                  CreateDate = x.CreateDate,    
                  User_Id = x.User_Id,
                  UserName = x.User.UserName,
                  Text = x.Text,
                  ProductName = x.Product.Name,
              },
              expression: x => x.Status != Domain.Enums.Status.Passive,
              orderBy: x => x.OrderBy(x => x.CreateDate));

            return comments;

        }
    }
}
