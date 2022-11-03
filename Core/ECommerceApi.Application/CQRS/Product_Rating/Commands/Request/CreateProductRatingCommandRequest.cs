using ECommerceApi.Application.CQRS.Product_Rating.Commands.Response;
using ECommerceApi.Domain.Enums;
using ECommerceApi.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Product_Rating.Commands.Request
{
    public class CreateProductRatingCommandRequest : IRequest<CreateProductRatingCommandResponse>
    {

        public int Product_Id { get; set; }
        public string User_Id { get; set; }
        public decimal Rating { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public Status Status { get; set; } = Status.Active;
    }
}
