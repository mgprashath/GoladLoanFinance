using GoldLoanFinance.Application.Interfaces;
using GoldLoanFinance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldLoanFinance.Application.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAllCustomers();
        }

        public bool AddCustomer(Customer customer)
        {
            return _customerRepository.AddCustomer(customer);   
        }

        public bool DeleteCustomer(int id)
        {
            return _customerRepository.DeleteCustomer(id);
        }

        public Customer? GetCustomer(int id)
        {
            return _customerRepository.GetCustomer(id);
        }

        public bool UpdateCustomer(Customer customer)
        {
            return _customerRepository.UpdateCustomer(customer);
        }
    }
}
