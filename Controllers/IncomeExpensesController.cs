using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyPort.Models.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EasyPort.Controllers
{
    public class IncomeExpensesController : Controller
    {
        private readonly ICompanyRepository _company;
        private readonly IIncomeExpensesRepository _incomeExpenses;
        private readonly IAspNetUserRepository _asp;

        public IncomeExpensesController(ICompanyRepository company, IIncomeExpensesRepository incomeExpenses, IAspNetUserRepository asp)
        {
            _company = company;
            _incomeExpenses = incomeExpenses;
            _asp = asp;
        }

        public IActionResult Index()
        {
            ViewBag.sDate = DateTime.Now.Date;
            ViewBag.eDate = DateTime.Now.Date;
            var user = _asp.FindBy(c => c.UserName == User.Identity.Name).FirstOrDefault();
            ViewBag.Period = $"FROM {DateTime.Now.Date.ToString("MMM dd, yyyy")} TO {DateTime.Now.Date.ToString("MMM dd, yyyy")}";
            var dt = _incomeExpenses.FindBy(c => c.Date.Date == DateTime.Now.Date).ToList();
            var gt = dt.GroupBy(c => c.TransactionType);
            return View(gt);
        }

        [HttpPost]
        public IActionResult Index(DateTime sDate, DateTime eDate)
        {
            ViewBag.sDate = sDate.Date;
            ViewBag.eDate = eDate.Date;
            ViewBag.Period = $"FROM {sDate.Date.ToString("MMM dd, yyyy")} TO {eDate.Date.ToString("MMM dd, yyyy")}";
            var user = _asp.FindBy(c => c.UserName == User.Identity.Name).FirstOrDefault();
            var dt = _incomeExpenses.FindBy(c => c.Date.Date >= sDate.Date && c.Date.Date <= eDate.Date && c.CompanyId == user.CompanyId).ToList();
            var gt = dt.GroupBy(c => c.TransactionType);
            return View(gt);
        }
    }
}