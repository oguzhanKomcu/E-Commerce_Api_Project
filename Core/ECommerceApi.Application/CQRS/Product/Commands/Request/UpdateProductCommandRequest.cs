using ECommerceApi.Application.CQRS.Product.Commands.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Product.Commands.Request
{
    public  class UpdateProductCommandRequest : IRequest<UpdateProductCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }

        public IFormFile? UploadPath { get; set; }

        public string ImagePath { get; set; }
        public int Stock { get; set; }
        public int Category_Id { get; set; }
        public ECommerceApi.Domain.Entities.Category Category { get; set; }
    }
}
