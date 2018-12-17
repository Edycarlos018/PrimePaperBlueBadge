using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimePaper.Models
{
    public class ContractCreate
    {
        [Display(Name = "Check if payment was made")]
        public bool PaymentReceived { get; set; }
        [Display(Name = "Payment method")]
        public string PaymentsMethod { get; set; }
        [Display(Name = "Contract Length")]
        public int ContractLength { get; set; }
        [Display(Name = "Customer ID")]
        public int CustomerID { get; set; }
        [Display(Name = "Product ID")]
        public int ProductId { get; set; }


        public override string ToString() => base.ToString();


    }
}
