using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimePaper.Models
{
   public class ContractEdit
    {
        public int ContractID { get; set; }
        public bool PaymentReceived { get; set; }
        public string PaymentsMethod { get; set; }
        public int ContractLength { get; set; }
    }
}
