using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRentalApp;

namespace RentalAppUI.Views
{
    public class RentalAgreementsController : Controller
    {
        private readonly RentalModel _context;

        public RentalAgreementsController(RentalModel context)
        {
            _context = context;
        }

        // GET: RentalAgreements
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reservervation.ToListAsync());
        }

        // GET: RentalAgreements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalAgreement = await _context.Reservervation
                .FirstOrDefaultAsync(m => m.RentalID == id);
            if (rentalAgreement == null)
            {
                return NotFound();
            }

            return View(rentalAgreement);
        }

        // GET: RentalAgreements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RentalAgreements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RentalID,ReservationEmail,DateOfPickup,LocationToPickup,DateOfReturn,LocationToDropOff,Destination,Drivers")] RentalAgreement rentalAgreement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentalAgreement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rentalAgreement);
        }

        // GET: RentalAgreements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalAgreement = await _context.Reservervation.FindAsync(id);
            if (rentalAgreement == null)
            {
                return NotFound();
            }
            return View(rentalAgreement);
        }

        // POST: RentalAgreements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RentalID,ReservationEmail,DateOfPickup,LocationToPickup,DateOfReturn,LocationToDropOff,Destination,Drivers")] RentalAgreement rentalAgreement)
        {
            if (id != rentalAgreement.RentalID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentalAgreement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalAgreementExists(rentalAgreement.RentalID))
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
            return View(rentalAgreement);
        }

        // GET: RentalAgreements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalAgreement = await _context.Reservervation
                .FirstOrDefaultAsync(m => m.RentalID == id);
            if (rentalAgreement == null)
            {
                return NotFound();
            }

            return View(rentalAgreement);
        }

        // POST: RentalAgreements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentalAgreement = await _context.Reservervation.FindAsync(id);
            _context.Reservervation.Remove(rentalAgreement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalAgreementExists(int id)
        {
            return _context.Reservervation.Any(e => e.RentalID == id);
        }
    }
}
