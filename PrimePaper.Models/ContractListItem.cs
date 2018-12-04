using PrimePaper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimePaper.Models
{
  public  class ContractListItem
    {
        public int ContractID { get; set; }
        public bool PaymentReceived { get; set; }
        public string PaymentsMethod { get; set; }
        public int ContractLength { get; set; }
        public int CustomerID { get; set; }
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
