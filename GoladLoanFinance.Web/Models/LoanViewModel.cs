using GoldLoanFinance.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GoldLoanFinance.Web.Models
{
    public class LoanViewModel
    {
        public LoanMaster? LoanMaster { get; set; }
        public List<SelectListItem>? CustomerList { get; set; }
        public string? LoanDetailsJson { get; set; }

        public string? CustomerName { get; set; } 
    }
}
