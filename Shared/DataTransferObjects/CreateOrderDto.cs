﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public class CreateOrderDto
    {
        public int CustomerId { get; set; }
        public string PaymentMethod { get; set; } = null!;
        public List<CreateOrderItemDto> Items { get; set; } = new();
    }
}
