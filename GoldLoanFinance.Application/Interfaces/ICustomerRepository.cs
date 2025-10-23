using GoldLoanFinance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldLoanFinance.Application.Interfaces
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();
        bool AddCustomer(Customer customer);
        bool DeleteCustomer(int id);
        Customer? GetCustomer(int id);
        bool UpdateCustomer(Customer customer);
    }
}
