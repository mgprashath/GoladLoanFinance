using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldLoanFinance.Domain.Entities
{
    public class Bank
    {
        [Key]
        public int BankId { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("Bank Name")]
        public string Name { get; set; }
    }
}
