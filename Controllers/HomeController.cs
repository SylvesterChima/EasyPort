using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EasyPort.Messages;
using Microsoft.AspNetCore.Mvc;
using EasyPort.Models;
using Microsoft.AspNetCore.Authorization;

namespace EasyPort.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMessageService _msg;

        public HomeController(IMessageService msg)
        {
            _msg = msg;
        }

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
            //_msg.SendEmailAsync("EasyPort", "sylvesterchima11@gmail.com", "Chima", "sylvesterchima11@outlook.com", "Demo", "Just a demo");
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
