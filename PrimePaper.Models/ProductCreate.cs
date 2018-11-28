using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimePaper.Models
{
   public class ProductCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Type { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        [MaxLength(8000)]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }

        public override string ToString() => Type;
        
    }
}
