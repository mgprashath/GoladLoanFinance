using GoldLoanFinance.Application.Services;
using GoldLoanFinance.Domain.Entities;
using GoldLoanFinance.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;

namespace GoldLoanFinance.Web.Controllers
{
    public class LoanController : Controller
    {
        private readonly CustomerService _customerService;
        private readonly LoanService _loanService;
        public LoanController(CustomerService customerService, LoanService loanService)
        {
            _customerService=customerService;
            _loanService=loanService;
        }
        public IActionResult Index()
        {
            LoanViewModel loanViewModel = new()
            {
                CustomerList = _customerService.GetAllCustomers().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.CustomerId.ToString()
                }).ToList(),
                LoanMaster = new LoanMaster()
            };

            return View(loanViewModel);
        }

        public IActionResult CreateLoan(LoanViewModel loanViewModel)
        {
            List<LoanDetails> loanDetails = new();
            if (!string.IsNullOrWhiteSpace(loanViewModel.LoanDetailsJson))
                loanDetails = JsonSerializer.Deserialize<List<LoanDetails>>(loanViewModel.LoanDetailsJson) ?? new();

            LoanMaster? loanMaster = loanViewModel.LoanMaster;

            if (loanMaster != null)
            {
                loanMaster.LoanDetails = loanDetails;
                bool result = _loanService.CreateLoan(loanMaster);
            }

            ViewBag.ResponseMessage = "Success";          

            return RedirectToAction("ListLoans");
        }

        public IActionResult UpdateLoan(LoanViewModel loanViewModel)
        {
            List<LoanDetails> loanDetails = new();
            if (!string.IsNullOrWhiteSpace(loanViewModel.LoanDetailsJson))
                loanDetails = JsonSerializer.Deserialize<List<LoanDetails>>(loanViewModel.LoanDetailsJson) ?? new();

            LoanMaster? loanMaster = loanViewModel.LoanMaster;

            if (loanMaster != null)
            {
                loanMaster.LoanDetails = loanDetails;
                bool result = _loanService.UpdateLoan(loanMaster);              
            }

            ViewBag.ResponseMessage = "Success";

            return RedirectToAction("ListLoans");
        }

        [HttpGet]
        public IActionResult ListLoans()
        {
            List<LoanMaster> loanMasters = _loanService.GetAllLoansNotRepledged();

            return View(loanMasters);
        }

        public IActionResult Edit(int id)
        {
            LoanMaster? loanMaster = _loanService.GetLoanById(id);

            LoanViewModel loanViewModel = new()
            {
                LoanMaster = loanMaster,
                CustomerList = _customerService.GetAllCustomers().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.CustomerId.ToString()
                }).ToList(),
                LoanDetailsJson = JsonSerializer.Serialize(loanMaster.LoanDetails
                .Select(u => new { u.ArticleId, u.ArticleName, u.Unit }).ToList())
            };

            return View(loanViewModel);
        }

        public IActionResult Delete(int id)
        {
            _loanService.DeleteLoan(id);

            return RedirectToAction("ListLoans");
        }

        public IActionResult Details(int id)
        {
            LoanMaster? loanMaster = _loanService.GetLoanById(id);

            if (loanMaster == null)
            {
                return NotFound();
            }

            LoanViewModel loanViewModel = new()
            {
                LoanMaster = loanMaster,
                CustomerName = loanMaster.Customer.Name
            };

            return View(loanViewModel);
        }



    }
}
