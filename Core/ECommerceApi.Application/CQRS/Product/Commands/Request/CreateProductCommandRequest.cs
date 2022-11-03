using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediatR;
using System.Threading.Tasks;
using ECommerceApi.Application.CQRS.Product.Commands.Response;
using Microsoft.AspNetCore.Http;
using ECommerceApi.Domain.Entities;
using ECommerceApi.Domain.Enums;

namespace ECommerceApi.Application.CQRS.Product.Commands.Request
{
    public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }

        public IFormFile? UploadPath { get; set; }

        public string ImagePath { get; set; }
        public int Stock { get; set; }
        public int Category_Id { get; set; }

        public DateTime CreateDate => DateTime.Now;

        public Status Status => Status.Active;
    }
}
