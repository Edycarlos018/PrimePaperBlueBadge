using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimePaper.Models
{
   public class ContractEdit
    {
        [Display(Name = "Contract ID")]
        public int ContractID { get; set; }
        [Display(Name = "Check if payment was made")]
        public bool PaymentReceived { get; set; }
        [Display(Name = "Payment method")]
        public string PaymentsMethod { get; set; }
        [Display(Name = "Contract Length")]
        public int ContractLength { get; set; }
    }
}
