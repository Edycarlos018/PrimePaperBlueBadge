using PrimePaper.Data;
using PrimePaper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimePaper.Services
{
    public class ContractService
    {
        private readonly Guid _userId;

        public ContractService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateContract(ContractCreate model)
        {
            var entity =
                new Contract()
                {
                    OwnerId = _userId,
                    PaymentReceived = model.PaymentReceived,
                    PaymentsMethod = model.PaymentsMethod,
                    ContractLength = model.ContractLength
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Contracts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ContractListItem> GetContracts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Contracts
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new ContractListItem
                                {
                                   ContractID = e.ContractID,
                                   PaymentReceived = e.PaymentReceived,
                                   PaymentsMethod = e.PaymentsMethod,
                                   ContractLength = e.ContractLength
                                }
                        );
                return query.ToArray();
            }
        }
    }
}
