using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyPort.Models;
using Microsoft.AspNetCore.Authorization;

namespace EasyPort.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            //if (User.Identity.IsAuthenticated)
            //{
            //    return RedirectToAction("Index", "DailySales");
            //}
            //else
            //{
            //    return LocalRedirect("/Identity/Account/Login");
            //}
            return View();
        }

    }
}
