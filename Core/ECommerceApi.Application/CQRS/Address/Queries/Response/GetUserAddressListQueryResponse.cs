using ECommerceApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Address.Queries.Response
{
    public class GetUserAddressListQueryResponse
    {
        public int Id { get; set; }
        public string Street { get; set; }


        public string Street2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string Zip { get; set; }

        public string UserID { get; set; }
        public Domain.Entities.AppUser AppUser { get; set; }
    }
}
