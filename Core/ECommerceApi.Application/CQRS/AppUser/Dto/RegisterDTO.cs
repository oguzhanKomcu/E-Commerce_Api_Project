using ECommerceApi.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.AppUser.Dto
{
    public class RegisterDTO
    {

        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }


        public IFormFile? UploadPath { get; set; }
        public string? ImagePath { get; set; }

        public DateTime CreateDate => DateTime.Now;
        public Status Status => Status.Active;
    }
}
