using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldLoanFinance.Domain.Entities
{
    public class Repledge
    {
        [Key]
        public int RepledgeId { get; set; }
        [Required]
        public decimal LoanAmountFromBank { get; set; }
        public DateTime DatePledged { get; set; } = DateTime.Now;

        [ForeignKey("Bank")]
        public int BankId { get; set; }
        public  Bank Bank { get; set; }

        [ForeignKey("Article")]
        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
