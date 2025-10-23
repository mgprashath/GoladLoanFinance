using GoldLoanFinance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldLoanFinance.Application.Interfaces
{
    public interface ILoanRepository
    {
        bool CreateLoan(LoanMaster loanMaster);
        List<LoanMaster> GetAllLoans();
        List<LoanMaster> GetAllLoansNotRepledged();
        bool MarkAsPledged(List<RepledgeDetails> repledgeDetails);
        bool UpdateLoan(LoanMaster loanMaster);
        LoanMaster? GetLoanById(int id);
        bool DeleteLoan(int id);
        bool RemovePledged(List<RepledgeDetails> repledgeDetails);
    }
}
