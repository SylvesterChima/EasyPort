using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EasyPort.Models.EasyPortData;
using EasyPort.Models.Abstract;

namespace EasyPort.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly ICompanyRepository _company;


        public CompaniesController(ICompanyRepository company)
        {
            _company = company;
        }

        // GET: Companies
        public async Task<IActionResult> Index()
        {
            return View(await _company.GetAll().ToListAsync());
        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _company.FindBy(m => m.CompanyId == id).FirstOrDefaultAsync();
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // GET: Companies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompanyId,CompanyName,Address,Email,Phone,Logo,Date")] Company company)
        {
            if (ModelState.IsValid)
            {
                _company.Add(company);
                await _company.Save(User.Identity.Name, "no IP");
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _company.FindBy(c => c.CompanyId == id).FirstOrDefaultAsync();
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompanyId,CompanyName,Address,Email,Phone,Logo,Date")] Company company)
        {
            if (id != company.CompanyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _company.Edit(company);
                    await _company.Save(User.Identity.Name, "no IP");
                }
                catch (Exception)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _company.FindBy(m => m.CompanyId == id).FirstOrDefaultAsync();
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var company = await _company.FindBy(m => m.CompanyId == id).FirstOrDefaultAsync();
            _company.Delete(company);
            await _company.Save(User.Identity.Name, "no IP");
            return RedirectToAction(nameof(Index));
        }

        //private bool CompanyExists(int id)
        //{
        //    return _context.Company.Any(e => e.CompanyId == id);
        //}
    }
}
