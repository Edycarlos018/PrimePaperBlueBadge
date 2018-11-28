using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimePaper.Models
{
   public class CustomerCreate
    {
        [Required]
        [MinLength(2, ErrorMessage ="Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage ="There are to many characters in this field")]
        public string BusinessName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string CellPhoneNumber { get; set; }
    }
}
