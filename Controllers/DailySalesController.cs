using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyPort.Models;
using EasyPort.Models.Abstract;
using EasyPort.Models.EasyPortData;
using Microsoft.AspNetCore.Mvc;

namespace EasyPort.Controllers
{
    public class DailySalesController : Controller
    {
        private readonly ICompanyRepository _company;
        private readonly IDailySalesRepository _dailySales;
        private readonly IAspNetUserRepository _asp;

        public DailySalesController(ICompanyRepository company, IDailySalesRepository dailySales, IAspNetUserRepository asp)
        {
            _company = company;
            _dailySales = dailySales;
            _asp = asp;
        }
        public IActionResult Index()
        {
            ViewBag.sDate = DateTime.Now.Date;
            ViewBag.eDate = DateTime.Now.Date;
            ViewBag.Period = $"FROM {DateTime.Now.Date.ToString("MMM dd, yyyy")} TO {DateTime.Now.Date.ToString("MMM dd, yyyy")}";
            List<DailySalesModel> dailies = new List<DailySalesModel>();
            DailySalesModel obj;
            var user = _asp.FindBy(c => c.UserName == User.Identity.Name).FirstOrDefault();
            var dt = _dailySales.FindBy(c => c.DateSold.Date == DateTime.Now.Date && c.CompanyId == user.CompanyId).ToList();
            var objs = dt.GroupBy(c => c.ProductName);

            foreach (var item in objs)
            {
                obj = new DailySalesModel();
                obj.Company = item.ToList().FirstOrDefault().Company;
                obj.CompanyId = item.ToList().FirstOrDefault().CompanyId;
                obj.ProductName = item.ToList().FirstOrDefault().ProductName;
                obj.ProductId = item.ToList().FirstOrDefault().ProductId;
                obj.Quntity = item.Sum(c => c.Quntity);
                obj.TotalCost = item.Sum(c => c.TotalCost);
                obj.TotalAmount = item.Sum(c => c.TotalAmount);

                dailies.Add(obj);
            }
            return View(dailies);
        }

        [HttpPost]
        public IActionResult Index(DateTime sDate, DateTime eDate)
        {
            ViewBag.sDate =sDate.Date;
            ViewBag.eDate = eDate.Date;
            ViewBag.Period = $"FROM {sDate.Date.ToString("MMM dd, yyyy")} TO {eDate.Date.ToString("MMM dd, yyyy")}";
            List<DailySalesModel> dailies = new List<DailySalesModel>();
            DailySalesModel obj;
            var user = _asp.FindBy(c => c.UserName == User.Identity.Name).FirstOrDefault();
            var dt = _dailySales.FindBy(c => c.DateSold.Date >= sDate.Date && c.DateSold.Date <= eDate.Date && c.CompanyId == user.CompanyId).ToList();
            var objs = dt.GroupBy(c => c.ProductName);

            foreach (var item in objs)
            {
                obj = new DailySalesModel();
                obj.Company = item.ToList().FirstOrDefault().Company;
                obj.CompanyId = item.ToList().FirstOrDefault().CompanyId;
                obj.ProductName = item.ToList().FirstOrDefault().ProductName;
                obj.ProductId = item.ToList().FirstOrDefault().ProductId;
                obj.Quntity = item.Sum(c => c.Quntity);
                obj.TotalCost = item.Sum(c => c.TotalCost);
                obj.TotalAmount = item.Sum(c => c.TotalAmount);

                dailies.Add(obj);
            }
            return View(dailies);
        }
    }
}