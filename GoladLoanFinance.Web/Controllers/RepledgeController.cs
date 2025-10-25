using GoldLoanFinance.Application.Interfaces;
using GoldLoanFinance.Application.Services;
using GoldLoanFinance.Domain.Entities;
using GoldLoanFinance.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GoldLoanFinance.Web.Controllers
{
    public class RepledgeController : Controller
    {
        private readonly RepledgeService _repledgeService;
        private readonly LoanService _loanService;
        private readonly BankServices _bankService;

        public RepledgeController(RepledgeService repledgeService, LoanService loanService, BankServices bankService)
        {
            _repledgeService = repledgeService;
            _loanService = loanService;
            _bankService = bankService; 
        }
        public IActionResult Index()
        {
            List<LoanMaster> loan = _loanService.GetAllLoansNotRepledged();
            if (loan == null)
            {
                return NotFound();
            }

            List<SelectListItem> banks = _bankService.GetAllBanks().Select(u=> new SelectListItem {
                 Text = u.Name,
                 Value = u.BankId.ToString()
            }).ToList();

            List<RepledgeViewModel> model = loan
                .SelectMany(l => l.LoanDetails, (l, d) => new RepledgeViewModel
                {
                    ArticleId = d.ArticleId,
                    LoanId = l.LoanId,
                    ArticleName = d.ArticleName,
                    Unit = d.Unit,
                    LoanAmount = l.LoanAmount,
                    DateTaken = l.DateTaken,
                    DueDate = l.DueDate,
                    Selected = false
                })
                .ToList();

            RepledgeMasterViewModel repledgeMaster = new RepledgeMasterViewModel();
            repledgeMaster.RepledgeViewModels = model;
            repledgeMaster.Banks = banks;

            return View(repledgeMaster);
        }
    
        public IActionResult CreateRepledge(RepledgeMasterViewModel model)
        {
            List<RepledgeDetails> selected = (model.RepledgeViewModels ?? new List<RepledgeViewModel>()).Where(x => x.Selected)
                .Select(x => new RepledgeDetails
                {
                    ArticleId = x.ArticleId
                })
                .ToList();

            RepledgeMaster? repledgeMaster = model.RepledgeMaster;
            if (repledgeMaster != null)
            {
                repledgeMaster.RepledgeDetails = selected;
                _repledgeService.CreateRepledge(repledgeMaster, selected);
            }

            return RedirectToAction("Index");
        }
    
        public IActionResult ListRepledgedItems()
        {
            List<RepledgeMaster> repledgeMasters = _repledgeService.GetAllRepledged();
            return View(repledgeMasters);
        }

        public IActionResult Edit(int id)
        {
            RepledgeMaster? repledgeMaster = _repledgeService.GetRepledgeItemsById(id);
            List<LoanMaster> loan = _loanService.GetAllLoans();

            if (repledgeMaster==null)
            {
                return NotFound();
            }

            List<SelectListItem> banks = _bankService.GetAllBanks().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.BankId.ToString()
            }).ToList();

            List<RepledgeViewModel> model = loan
               .SelectMany(l => l.LoanDetails, (l, d) => new RepledgeViewModel
               {
                   ArticleId = d.ArticleId,
                   LoanId = l.LoanId,
                   ArticleName = d.ArticleName,
                   Unit = d.Unit,
                   LoanAmount = l.LoanAmount,
                   DateTaken = l.DateTaken,
                   DueDate = l.DueDate,
                   Selected = d.IsPledgedToBank
               })
               .ToList();

            RepledgeMasterViewModel repledgeMasterViewModel = new RepledgeMasterViewModel();

            repledgeMasterViewModel.RepledgeMaster= repledgeMaster;
            repledgeMasterViewModel.RepledgeViewModels = model;
            repledgeMasterViewModel.Banks = banks;

            return View(repledgeMasterViewModel);
        }

        public IActionResult Update(RepledgeMasterViewModel model)
        {
            List<RepledgeDetails> selected = new();
            List<RepledgeDetails> notSelected = new();

            foreach (var x in model.RepledgeViewModels ?? new List<RepledgeViewModel>())
            {
                var item = new RepledgeDetails { ArticleId = x.ArticleId };

                if (x.Selected)
                {
                    selected.Add(item);
                }
                else
                {
                    notSelected.Add(item);
                }
            }

            RepledgeMaster? repledgeMaster = model.RepledgeMaster;
            if (repledgeMaster != null)
            {
                repledgeMaster.RepledgeDetails = selected;
                _repledgeService.UpdateRepledge(repledgeMaster, selected, notSelected);
            }

            return RedirectToAction("ListRepledgedItems");
        }

        public IActionResult Delete(int id)
        {
            _repledgeService.DeleteRepledge(id);

            return RedirectToAction("ListRepledgedItems");
        }

        public IActionResult Details(int id) 
        {
            RepledgeMaster? loan = _repledgeService.GetRepledgeItemsById(id);
            if (loan == null)
            {
                return NotFound();
            }

            List<SelectListItem> banks = _bankService.GetAllBanks().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.BankId.ToString()
            }).ToList();

            List<RepledgeViewModel> repledgeViewModels = new List<RepledgeViewModel>();

            foreach (RepledgeDetails item in loan.RepledgeDetails)
            {
                RepledgeViewModel val = new RepledgeViewModel();

                val.ArticleId = item.ArticleId;
                val.Unit = item.LoanDetails.Unit;
                val.LoanId = item.LoanDetails.LoanId;
                val.ArticleName = item.LoanDetails.ArticleName;
                val.DateTaken = item.LoanDetails.LoanMaster.DateTaken;
                val.DueDate = item.LoanDetails.LoanMaster.DueDate;
                val.LoanAmount = item.LoanDetails.LoanMaster.LoanAmount;
                val.Selected = true;

                repledgeViewModels.Add(val);
            }

            RepledgeMasterViewModel repledgeMaster = new RepledgeMasterViewModel();
            repledgeMaster.RepledgeMaster = loan;
            repledgeMaster.RepledgeViewModels = repledgeViewModels;
            repledgeMaster.Banks = banks;

            return View(repledgeMaster);
        }
    }
}   
