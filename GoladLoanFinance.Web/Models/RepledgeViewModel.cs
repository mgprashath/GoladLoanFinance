using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GoldLoanFinance.Web.Models
{
    public class RepledgeViewModel
    {
        public int ArticleId { get; set; }
        public int LoanId { get; set; }
        public string ArticleName { get; set; } = string.Empty;
        public uint Unit { get; set; } = default;
        public decimal LoanAmount { get; set; }
        public DateTime DateTaken { get; set; }
        public DateTime DueDate { get; set; }
        public bool Selected { get; set; }
       
    }
}
