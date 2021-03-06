﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimePaper.Models
{
   public class ProductListItem
    {
        [Display(Name = "Product ID")]
        public int ProductId { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
