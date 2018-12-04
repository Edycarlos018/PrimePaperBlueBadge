using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimePaper.Data
{
    public class Contract
    {
        public int ContractID {get;set;}
        public int CustomerID { get; set; }
        public int ProductId { get; set; }
        public Guid OwnerId { get; set; }
        public bool PaymentReceived { get; set; }
        public string PaymentsMethod { get; set; }
        public int ContractLength { get; set; }

        public virtual Customer Customer { get; set;}
        public virtual Product Product { get; set;}
    }
}
