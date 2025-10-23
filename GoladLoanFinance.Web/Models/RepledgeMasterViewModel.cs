using GoldLoanFinance.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GoldLoanFinance.Web.Models
{
    public class RepledgeMasterViewModel
    {
        public RepledgeMaster? RepledgeMaster { get; set; }

        public List<RepledgeViewModel>? RepledgeViewModels { get; set; }

        public List<SelectListItem>? Banks { get; set; }

    }
}
