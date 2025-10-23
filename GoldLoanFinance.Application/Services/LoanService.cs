using GoldLoanFinance.Application.Interfaces;
using GoldLoanFinance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldLoanFinance.Application.Services
{
    public class LoanService
    {
        private readonly ILoanRepository _loanRepository;
        public LoanService(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public bool CreateLoan(LoanMaster loanMaster)
        {
            return _loanRepository.CreateLoan(loanMaster);
        }

        public bool UpdateLoan(LoanMaster loanMaster)
        {
            return _loanRepository.UpdateLoan(loanMaster);
        }

        public List<LoanMaster> GetAllLoans()
        {
            return _loanRepository.GetAllLoans();
        }

        public List<LoanMaster> GetAllLoansNotRepledged()
        {
            return _loanRepository.GetAllLoansNotRepledged();
        }

        public LoanMaster? GetLoanById(int id)
        {
            return _loanRepository.GetLoanById(id);
        }

        public bool DeleteLoan(int id)
        {
            return _loanRepository.DeleteLoan(id);
        }
    }
}
