using GoldLoanFinance.Application.Interfaces;
using GoldLoanFinance.Domain.Entities;
using GoldLoanFinance.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldLoanFinance.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _db;

        public CustomerRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Customer> GetAllCustomers() 
        {
            return _db.Customers.ToList();
        }

        public bool AddCustomer(Customer customer)
        {
            _db.Customers.Add(customer);
            return _db.SaveChanges() > 0;
        }

        public bool DeleteCustomer(int id) {
            Customer? customer = _db.Customers.Find(id);
            if (customer == null)
            {
                return false;
            }
            _db.Customers.Remove(customer);
            return _db.SaveChanges() > 0;
        }

        public Customer? GetCustomer(int id)
        {
            return _db.Customers.Find(id);
        }

        public bool UpdateCustomer(Customer customer)
        {
            _db.Customers.Update(customer);
            return _db.SaveChanges() > 0;
        }
    }
}
    