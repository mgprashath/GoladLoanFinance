using GoldLoanFinance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldLoanFinance.Application.Interfaces
{
    public interface IBankRepository
    {
        List<Bank> GetAllBanks();
        bool AddBank(Bank bank);
        bool DeleteBank(int id);
        Bank? GetBank(int id);
        bool UpdateBank(Bank bank);
    }
}
