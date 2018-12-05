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
        public int ContractID { get; set; }
        public string BusinessName { get; set; }
        public string Type { get; set; }
        public bool PaymentReceived { get; set; }
        public int ContractLength { get; set; }
        public string PaymentsMethod { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        public override string ToString() => $"[{ContractID}] {BusinessName}";
    }
}
