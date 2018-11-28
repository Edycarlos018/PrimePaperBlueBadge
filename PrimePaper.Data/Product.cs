﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimePaper.Data
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        
    }
}
