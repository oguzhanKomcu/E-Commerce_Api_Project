using ECommerceApi.Application.CQRS.Address.Commands.Response;
using ECommerceApi.Domain.Entities;
using ECommerceApi.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Address.Commands.Request
{
    public class CreateAddressCommandRequest : IRequest<CreateAddressCommandResponse>
    {
        public string Street { get; set; }


        public string Street2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string Zip { get; set; }

        public string UserID { get; set; }
        public Domain.Entities.AppUser AppUser { get; set; }

        public DateTime CreateDate => DateTime.Now;

        public Status Status => Status.Active;


    }
}
