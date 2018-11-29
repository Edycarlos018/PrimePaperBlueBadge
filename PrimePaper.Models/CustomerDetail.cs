using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimePaper.Models
{
  public  class CustomerDetail
    {
        public int CustomerID { get; set; }
        public string BusinessName { get; set; }
        public string Address { get; set; }
        public string CellPhoneNumber { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        public override string ToString() => $"[{CustomerID}] {BusinessName}";
    }
}
