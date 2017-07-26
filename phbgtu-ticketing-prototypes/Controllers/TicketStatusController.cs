using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using phbgtu_ticketing_prototypes.Data;
using phbgtu_ticketing_prototypes.Models;

namespace phbgtu_ticketing_prototypes.Controllers
{
    public class TicketStatusController : Controller
    {
        private readonly TicketContext _context;

        public TicketStatusController(TicketContext context)
        {
            _context = context;    
        }

        // GET: TicketStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.TicketStatuses.ToListAsync());
        }

        // GET: TicketStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketStatus = await _context.TicketStatuses
                .SingleOrDefaultAsync(m => m.TicketStatusID == id);
            if (ticketStatus == null)
            {
                return NotFound();
            }

            return View(ticketStatus);
        }

        // GET: TicketStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TicketStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TicketStatusID,TicketStatusName")] TicketStatus ticketStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticketStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ticketStatus);
        }

        // GET: TicketStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketStatus = await _context.TicketStatuses.SingleOrDefaultAsync(m => m.TicketStatusID == id);
            if (ticketStatus == null)
            {
                return NotFound();
            }
            return View(ticketStatus);
        }

        // POST: TicketStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TicketStatusID,TicketStatusName")] TicketStatus ticketStatus)
        {
            if (id != ticketStatus.TicketStatusID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticketStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketStatusExists(ticketStatus.TicketStatusID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(ticketStatus);
        }

        // GET: TicketStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketStatus = await _context.TicketStatuses
                .SingleOrDefaultAsync(m => m.TicketStatusID == id);
            if (ticketStatus == null)
            {
                return NotFound();
            }

            return View(ticketStatus);
        }

        // POST: TicketStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticketStatus = await _context.TicketStatuses.SingleOrDefaultAsync(m => m.TicketStatusID == id);
            _context.TicketStatuses.Remove(ticketStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TicketStatusExists(int id)
        {
            return _context.TicketStatuses.Any(e => e.TicketStatusID == id);
        }
    }
}
