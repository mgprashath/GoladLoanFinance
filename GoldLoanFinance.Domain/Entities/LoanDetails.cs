using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldLoanFinance.Domain.Entities
{
    public class LoanDetails
    {
        [Key]
        public int ArticleId { get; set; }
        [Required]
        public string ArticleName { get; set; }
        [Required]
        public uint Unit { get; set; } = default;

        public bool IsPledgedToBank { get; set; } = false;

        [Required]
        [ForeignKey("LoanMaster")]
        public int LoanId { get; set; }
        public LoanMaster LoanMaster { get; set; }
    }
}
