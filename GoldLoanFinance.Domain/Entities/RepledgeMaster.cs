using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace GoldLoanFinance.Domain.Entities
{
    public class RepledgeMaster
    {
        [Key]
        [DisplayName("Repledge Id")]
        public int RepledgeId { get; set; }
        [Required]
        [DisplayName("Loan Amount From Bank")]
        public decimal LoanAmountFromBank { get; set; }
        [DisplayName("Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DatePledged { get; set; } = DateTime.Today;

        [Required]
        [ForeignKey("Bank")]
        public int BankId { get; set; }
        public  Bank Bank { get; set; }

        public List<RepledgeDetails> RepledgeDetails { get; set; }

    }
}
