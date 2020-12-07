using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NETD_Lab52.Data;
using NETD_Lab52.Models;

namespace NETD_Lab52.Controllers
{
    public class HoldsController : Controller
    {
        private readonly LibraryContext _context;

        public HoldsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Holds
        public async Task<IActionResult> Index()
        {
            var libraryContext = _context.Holds.Include(h => h.Book).Include(h => h.Client);
            return View(await libraryContext.ToListAsync());
        }

        // GET: Holds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hold = await _context.Holds
                .Include(h => h.Book)
                .Include(h => h.Client)
                .FirstOrDefaultAsync(m => m.HoldID == id);
            if (hold == null)
            {
                return NotFound();
            }

            return View(hold);
        }

        // GET: Holds/Create
        public IActionResult Create()
        {
            ViewData["BookID"] = new SelectList(_context.Books, "BookID", "BookID");
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "ClientID");
            return View();
        }

        // POST: Holds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HoldID,BookID,ClientID")] Hold hold)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hold);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookID"] = new SelectList(_context.Books, "BookID", "BookID", hold.BookID);
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "ClientID", hold.ClientID);
            return View(hold);
        }

        // GET: Holds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hold = await _context.Holds.FindAsync(id);
            if (hold == null)
            {
                return NotFound();
            }
            ViewData["BookID"] = new SelectList(_context.Books, "BookID", "BookID", hold.BookID);
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "ClientID", hold.ClientID);
            return View(hold);
        }

        // POST: Holds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HoldID,BookID,ClientID")] Hold hold)
        {
            if (id != hold.HoldID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hold);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoldExists(hold.HoldID))
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
            ViewData["BookID"] = new SelectList(_context.Books, "BookID", "BookID", hold.BookID);
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "ClientID", hold.ClientID);
            return View(hold);
        }

        // GET: Holds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hold = await _context.Holds
                .Include(h => h.Book)
                .Include(h => h.Client)
                .FirstOrDefaultAsync(m => m.HoldID == id);
            if (hold == null)
            {
                return NotFound();
            }

            return View(hold);
        }

        // POST: Holds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hold = await _context.Holds.FindAsync(id);
            _context.Holds.Remove(hold);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoldExists(int id)
        {
            return _context.Holds.Any(e => e.HoldID == id);
        }
    }
}
