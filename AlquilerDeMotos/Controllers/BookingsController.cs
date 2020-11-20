using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotorcycleRent.Data;
using MotorcycleRent.Models;

namespace MotorcycleRent.Controllers
{
    [Authorize(Roles = "user")]
    public class BookingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public BookingsController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            AppUser appUser = await _userManager.GetUserAsync(User);
            var booking = await _context.Booking.OrderBy(b => b.BookingStart).Include(a=>a.Motorcycle).Where(b => b.IdAppUser == appUser.Id).ToListAsync();
            return View(booking);
        }

        public async Task<IActionResult> Pay(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking.FirstOrDefaultAsync(m => m.Id == id);
            DateTime now = DateTime.Now;
            booking.Delivery = now;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);

                    var motorcycle = await _context.Motorcycle.FirstOrDefaultAsync(m => m.Id == booking.IdMotorcycle);

                    motorcycle.Rented = false;

                    _context.Update(motorcycle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotorcycleExists(booking.Id))
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
            return View(booking);
        }

        private bool MotorcycleExists(int id)
        {
            return _context.Motorcycle.Any(e => e.Id == id);
        }

    }
}
