using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldLoanFinance.Domain.Entities
{
    public class RepledgeDetails
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("RepledgeMaster")]
        public int RepledgeId { get; set; }
        public RepledgeMaster RepledgeMaster { get; set; }

        [Required]
        [ForeignKey("LoanDetails")]
        public int ArticleId { get; set; }
        public LoanDetails LoanDetails { get; set; }

    }
}
