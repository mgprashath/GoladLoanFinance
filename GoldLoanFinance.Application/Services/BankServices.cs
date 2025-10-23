using GoldLoanFinance.Application.Interfaces;
using GoldLoanFinance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldLoanFinance.Application.Services
{
    public class BankServices
    {
        private readonly IBankRepository _bankRepository;

        public BankServices(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public List<Bank> GetAllBanks()
        {
            return _bankRepository.GetAllBanks();
        }

        public bool AddBank(Bank bank)
        {
            return _bankRepository.AddBank(bank);
        }

        public bool DeleteBank(int id)
        {
            return _bankRepository.DeleteBank(id);
        }

        public Bank? GetBank(int id)
        {
            return _bankRepository.GetBank(id);
        }

        public bool UpdateBank(Bank bank)
        {
            return _bankRepository.UpdateBank(bank);
        }
    }
}
