﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Product.Commands.Response
{
    public class CreateProductCommandResponse
    {
        public bool IsSuccess { get; set; }
        public int ProductId { get; set; }
    }
}
