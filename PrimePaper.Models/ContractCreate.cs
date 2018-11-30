using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimePaper.Models
{
   public class ContractCreate
    {
        public bool PaymentReceived { get; set; }
        public string PaymentsMethod { get; set; }
        public int ContractLength { get; set; }
        public int CustomerID { get; set; }
        public int ProductId { get; set; }


        public override string ToString() => base.ToString();
    }
}
