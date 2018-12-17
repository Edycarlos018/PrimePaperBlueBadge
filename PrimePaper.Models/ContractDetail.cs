using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimePaper.Models
{
    public class ContractDetail
    {
        [Display(Name = "Product ID")]
        public int ContractID { get; set; }
        [Display(Name = "Name of Business")]
        public string BusinessName { get; set; }
        public string Type { get; set; }
        [Display(Name = "Check if payment was made")]
        public bool PaymentReceived { get; set; }
        [Display(Name = "Contract Length")]
        public int ContractLength { get; set; }
        [Display(Name = "Payment method")]
        public string PaymentsMethod { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        public override string ToString() => $"[{ContractID}] {BusinessName}";
    }
}
