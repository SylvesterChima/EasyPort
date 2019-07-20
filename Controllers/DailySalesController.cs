using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyPort.Models.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EasyPort.Controllers
{
    public class DailySalesController : Controller
    {
        private readonly ICompanyRepository _company;
        private readonly IDailySalesRepository _dailySales;

        public DailySalesController(ICompanyRepository company, IDailySalesRepository dailySales)
        {
            _company = company;
            _dailySales = dailySales;
        }
        public IActionResult Index()
        {
            ViewBag.sDate = DateTime.Now.Date;
            ViewBag.eDate = DateTime.Now.Date;
            var dt = _dailySales.FindBy(c => c.DateSold.Date == DateTime.Now.Date).ToList();
            return View(dt);
        }
    }
}