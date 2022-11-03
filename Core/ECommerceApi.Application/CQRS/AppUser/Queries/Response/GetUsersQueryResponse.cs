using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.AppUser.Queries.Response
{
    public  class GetUsersQueryResponse 
    {
        public string  UserId { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string ImagePath { get; set; }
        public string UserName { get; set; }

    }
}
