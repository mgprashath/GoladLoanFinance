using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldLoanFinance.Domain.Entities
{
    public class Loan
    {
        [Key]
        public int LoanId { get; set; }        
        [Required]
        public decimal LoanAmount { get; set; }
        public DateTime DateTaken { get; set; }= DateTime.Now;
        public DateTime DueDate { get; set; }= DateTime.Now.AddYears(1);
        public bool IsPledgedToBank { get; set; } = false;

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("Article")]
        public int ArticleId { get; set; }
        public Article Article { get; set; }

    }
}
