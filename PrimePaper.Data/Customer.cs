using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimePaper.Data
{
   public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string BusinessName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string CellPhoneNumber { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
