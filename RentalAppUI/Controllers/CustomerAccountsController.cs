using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRentalApp;
using Microsoft.AspNetCore.Authorization;

namespace RentalAppUI.Controllers
{
    [Authorize]
    public class CustomerAccountsController : Controller
    {
        private readonly RentalModel _context;

        public CustomerAccountsController(RentalModel context)
        {
            _context = context;
        }

        // GET: CustomerAccounts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Accounts.ToListAsync());
        }

        // GET: CustomerAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerAccounts = await _context.Accounts
                .FirstOrDefaultAsync(m => m.CustomerAccountNumber == id);
            if (customerAccounts == null)
            {
                return NotFound();
            }

            return View(customerAccounts);
        }

        // GET: CustomerAccounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerName,CustomerAddress,CustomerPhoneNumber,CustomerEmailAddress,CustomerDriversLicenseNumber,CustomerCreditCardNumber,CustomerAccountNumber,CustomerAccountCreationDate")] CustomerAccounts customerAccounts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerAccounts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerAccounts);
        }

        // GET: CustomerAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerAccounts = await _context.Accounts.FindAsync(id);
            if (customerAccounts == null)
            {
                return NotFound();
            }
            return View(customerAccounts);
        }

        // POST: CustomerAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerName,CustomerAddress,CustomerPhoneNumber,CustomerEmailAddress,CustomerDriversLicenseNumber,CustomerCreditCardNumber,CustomerAccountNumber,CustomerAccountCreationDate")] CustomerAccounts customerAccounts)
        {
            if (id != customerAccounts.CustomerAccountNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerAccounts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerAccountsExists(customerAccounts.CustomerAccountNumber))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customerAccounts);
        }

        // GET: CustomerAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerAccounts = await _context.Accounts
                .FirstOrDefaultAsync(m => m.CustomerAccountNumber == id);
            if (customerAccounts == null)
            {
                return NotFound();
            }

            return View(customerAccounts);
        }

        // POST: CustomerAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerAccounts = await _context.Accounts.FindAsync(id);
            _context.Accounts.Remove(customerAccounts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerAccountsExists(int id)
        {
            return _context.Accounts.Any(e => e.CustomerAccountNumber == id);
        }
    }
}
