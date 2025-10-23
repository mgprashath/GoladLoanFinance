using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldLoanFinance.Domain.Entities
{
    public class LoanMaster
    {
        [Key]
        public int LoanId { get; set; }        
        [Required]
        public decimal LoanAmount { get; set; }
        public DateTime DateTaken { get; set; }
        public DateTime DueDate { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public List<LoanDetails> LoanDetails { get; set; } = new();
    }
}
