using PrimePaper.Data;
using PrimePaper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimePaper.Services
{
   public class CustomerService
    {
        private readonly Guid _userId;

        public CustomerService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateCustomer(CustomerCreate model)
        {
            var entity =
                new Customer()
                {
                    OwnerId = _userId,
                    BusinessName = model.BusinessName,
                    Address = model.Address,
                    CellPhoneNumber = model.CellPhoneNumber,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CustomerListItem> GetCustomers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Customers
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new CustomerListItem
                                {
                                    CustomerID = e.CustomerID,
                                    BusinessName = e.BusinessName,
                                    Address = e.Address,
                                    CellPhoneNumber = e.CellPhoneNumber,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                return query.ToArray();
            }
        }
        public CustomerDetail GetCustomerById(int customerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerID == customerId && e.OwnerId == _userId);
                return
                    new CustomerDetail
                    {
                        CustomerID = entity.CustomerID,
                        BusinessName = entity.BusinessName,
                        Address = entity.Address,
                        CellPhoneNumber = entity.CellPhoneNumber,
                        CreatedUtc = entity.CreatedUtc
                    };
            }
        }
        public bool UpdateCustomer(CustomerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerID == model.CustomerID && e.OwnerId == _userId);
                entity.BusinessName = model.BusinessName;
                entity.Address = model.Address;
                entity.CellPhoneNumber = model.CellPhoneNumber;
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
