﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public class ProductDTO : BaseDto
    {
        public string Name { get; set; }
        public int Stok { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

    }
}
