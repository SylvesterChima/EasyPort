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

        public IncomeExpensesController(ICompanyRepository company, IIncomeExpensesRepository incomeExpenses)
        {
            _company = company;
            _incomeExpenses = incomeExpenses;
        }
        public IActionResult Index()
        {
            ViewBag.sDate = DateTime.Now.Date;
            ViewBag.eDate = DateTime.Now.Date;
            var dt = _incomeExpenses.FindBy(c => c.Date.Date == DateTime.Now.Date).ToList();
            return View(dt);
        }
    }
}