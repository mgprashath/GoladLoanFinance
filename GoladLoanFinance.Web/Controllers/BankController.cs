using GoldLoanFinance.Application.Services;
using GoldLoanFinance.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GoldLoanFinance.Web.Controllers
{
    public class BankController : Controller
    {
        private readonly BankServices _bankServices;

        public BankController(BankServices bankServices)
        {
            _bankServices = bankServices;
        }
        public IActionResult Index()
        {
            List<Bank> list = _bankServices.GetAllBanks();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Bank bank)
        {
            bool result = _bankServices.AddBank(bank);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Bank? bank = _bankServices.GetBank(id);
            if (bank == null)
            {
                return RedirectToAction("Index");
            }
            return View(bank);
        }

        public IActionResult Update(Bank bank)
        {
            bool result = _bankServices.UpdateBank(bank);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Bank? bank = _bankServices.GetBank(id);
            if (bank == null)
            {
                return RedirectToAction("Index");
            }
            return View(bank);
        }

        public IActionResult Delete(int id)
        {
            bool result = _bankServices.DeleteBank(id);
            return RedirectToAction("Index");
        }
    }
}
