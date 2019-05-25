using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AccountManager.Data;
using AccountManager.Data.Models;
using AccountManager.Data.DataServices;
using AccountManager.Data.Models.DTO;

namespace AccountManager.UI.MVC.Controllers
{
    public class AccountTypesController : Controller
    {
        private readonly AccountTypeDataService service;

        public AccountTypesController(AccountTypeDataService service)
        {
            this.service = service;
        }

        // GET: AccountTypes
        public async Task<IActionResult> Index()
        {
            return View(service.GetAll<AccountTypeDTO>());
        }

        // GET: AccountTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountTypeDTO = service.GetById<AccountTypeDTO>(id.Value);

            if (accountTypeDTO == null)
            {
                return NotFound();
            }

            return View(accountTypeDTO);
        }

        // GET: AccountTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AccountTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AccountTypeDTO accountTypeDTO)
        {
            if (ModelState.IsValid)
            {
                service.AddOrUpdate(accountTypeDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(accountTypeDTO);
        }

        // GET: AccountTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountTypeDTO = service.GetById<AccountTypeDTO>(id.Value);

            if (accountTypeDTO == null)
            {
                return NotFound();
            }
            return View(accountTypeDTO);
        }

        // POST: AccountTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  AccountTypeDTO accountTypeDTO)
        {
            if (id != accountTypeDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    service.AddOrUpdate(accountTypeDTO);
                }
                catch (DbUpdateConcurrencyException)
                {
                     return NotFound();
                 
                }
                return RedirectToAction(nameof(Index));
            }
            return View(accountTypeDTO);
        }

        // GET: AccountTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountTypeDTO = service.GetById<AccountTypeDTO>(id.Value);
            if (accountTypeDTO == null)
            {
                return NotFound();
            }
            return View(accountTypeDTO);
            
        }

        // POST: AccountTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
