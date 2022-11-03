using ECommerceApi.Application.CQRS.Product_Rating.Commands.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Product_Rating.Commands.Request
{
    public  class IsRatingExsistProductRatingCommandRequest : IRequest<IsRatingExsistProductRatingCommandResponse>
    {
        public int Product_Id { get; set; }
        public string User_Id { get; set; }

    }
}
