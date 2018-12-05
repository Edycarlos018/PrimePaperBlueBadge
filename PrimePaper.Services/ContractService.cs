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
                    CustomerID = model.CustomerID,
                    ProductId = model.ProductId,
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
                                    CustomerID = e.CustomerID,
                                    BusinessName = e.Customer.BusinessName,
                                    Type = e.Product.Type,
                                    ProductId = e.ProductId,
                                    PaymentReceived = e.PaymentReceived,
                                    PaymentsMethod = e.PaymentsMethod,
                                    ContractLength = e.ContractLength
                                }
                        );
                return query.ToArray();
            }
        }
        public ContractDetail GetContractById(int contractId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Contracts
                        .Single(e => e.ContractID == contractId && e.OwnerId == _userId);
                return
                    new ContractDetail
                    {
                        ContractID = entity.ContractID,
                        BusinessName = entity.Customer.BusinessName,
                        Type = entity.Product.Type,
                        PaymentReceived = entity.PaymentReceived,
                        ContractLength = entity.ContractLength,
                       PaymentsMethod  = entity.PaymentsMethod
                    };
            }
        }
        public bool UpdateContract(ContractEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Contracts
                        .Single(e => e.ContractID == model.ContractID && e.OwnerId == _userId);
                entity.ContractID = model.ContractID;
                entity.PaymentReceived = model.PaymentReceived;
                entity.PaymentsMethod = model.PaymentsMethod;
                entity.ContractLength = model.ContractLength;

                return ctx.SaveChanges() == 1;

            }
        }
    }
}
