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
    public class BankRepository: IBankRepository
    {
        private readonly ApplicationDbContext _db;

        public BankRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Bank> GetAllBanks()
        {
            return _db.Banks.ToList();
        }

        public bool AddBank(Bank bank)
        {
            _db.Banks.Add(bank);
            return _db.SaveChanges() > 0;
        }

        public bool DeleteBank(int id)
        {
            Bank? bank = _db.Banks.Find(id);
            if (bank == null)
            {
                return false;
            }
            _db.Banks.Remove(bank);
            return _db.SaveChanges() > 0;
        }

        public Bank? GetBank(int id)
        {
            return _db.Banks.Find(id);
        }

        public bool UpdateBank(Bank bank)
        {
            _db.Banks.Update(bank);
            return _db.SaveChanges() > 0;
        }
    }
}
