using PrimePaper.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimePaper.Models
{
  public  class ContractListItem
    {
        [Display(Name = "Contract ID")]
        public int ContractID { get; set; }
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

        public virtual Customer Customer { get; set; }
        public string BusinessName { get; set; }

        public virtual Product Product { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
