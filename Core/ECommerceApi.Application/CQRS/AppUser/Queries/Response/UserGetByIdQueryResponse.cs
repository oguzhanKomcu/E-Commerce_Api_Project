using ECommerceApi.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.AppUser.Queries.Response
{
    public class UserGetByIdQueryResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Imagepath { get; set; }

        public DateTime UpdateDate => DateTime.Now;
        public Status Status => Status.Modified;

        public IFormFile UploadPath { get; set; }
    }
}
