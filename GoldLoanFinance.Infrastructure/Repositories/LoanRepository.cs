using GoldLoanFinance.Application.Interfaces;
using GoldLoanFinance.Domain.Entities;
using GoldLoanFinance.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldLoanFinance.Infrastructure.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly ApplicationDbContext _db;
        public LoanRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CreateLoan(LoanMaster loanMaster)
        {
            _db.LoanMaster.Add(loanMaster);
            return _db.SaveChanges() > 0;
        }

        public bool UpdateLoan(LoanMaster loanMaster)
        {
            var oldLoanDetails = _db.LoanDetails.Where(x => x.LoanId == loanMaster.LoanId);
            _db.LoanDetails.RemoveRange(oldLoanDetails);
            _db.LoanMaster.Update(loanMaster);
            return _db.SaveChanges() > 0;
        }

        public bool DeleteLoan(int id)
        {
            var removingItem = _db.LoanMaster.Find(id);

            if (removingItem != null)
            {
                _db.Remove(removingItem);
            }

            return _db.SaveChanges() > 0;
        }

        public List<LoanMaster> GetAllLoans()
        {
            return _db.LoanMaster.Include(l=>l.LoanDetails).Include(l=>l.Customer).ToList();
        }

        public LoanMaster? GetLoanById(int id)
        {
            return _db.LoanMaster.Include(u=>u.Customer).Include(u => u.LoanDetails).FirstOrDefault(u => u.LoanId == id);
        }

        public List<LoanMaster> GetAllLoansNotRepledged()
        {
            return _db.LoanMaster.Where(m => m.LoanDetails.Any(d => !d.IsPledgedToBank))
                .Include(m => m.LoanDetails.Where(d => !d.IsPledgedToBank))
                .Include(m => m.Customer).ToList();
        }

        public bool MarkAsPledged(List<RepledgeDetails> repledgeDetails)
        {
            var result = _db.LoanDetails
                .Where(id => repledgeDetails.Select(rd => rd.ArticleId).Contains(id.ArticleId))
                .ExecuteUpdate(u => u.SetProperty(x => x.IsPledgedToBank, true));
            return result > 0;
        }

        public bool RemovePledged(List<RepledgeDetails> repledgeDetails)
        {
            var result = _db.LoanDetails
                .Where(id => repledgeDetails.Select(rd => rd.ArticleId).Contains(id.ArticleId))
                .ExecuteUpdate(u => u.SetProperty(x => x.IsPledgedToBank, false));
            return result > 0;
        }
    }
}
