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
    public class EventTicketsController : Controller
    {
        private readonly TicketContext _context;

        public EventTicketsController(TicketContext context)
        {
            _context = context;    
        }

        // GET: EventTickets
        public async Task<IActionResult> Index()
        {
            var ticketContext = _context.EventTickets.Include(e => e.TicketDesign).Include(e => e.TicketType);
            return View(await ticketContext.ToListAsync());
        }

        // GET: EventTickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventTicket = await _context.EventTickets
                .Include(e => e.TicketDesign)
                .Include(e => e.TicketType)
                .SingleOrDefaultAsync(m => m.EventTicketID == id);
            if (eventTicket == null)
            {
                return NotFound();
            }

            return View(eventTicket);
        }

        // GET: EventTickets/Create
        public IActionResult Create(int? id)
        {

            ViewData["TicketDesignID"] = new SelectList(_context.TicketDesigns, "TicketDesignID", "TicketDesignID");
            ViewData["TicketTypeID"] = new SelectList(_context.TicketTypes, "TicketTypeID", "TicketTypeID");
            return View();
        }

        // POST: EventTickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventTicketID,QuantityAvailable,TicketTypeID,TicketDesignID,TicketPrice")] EventTicket eventTicket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventTicket);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["TicketDesignID"] = new SelectList(_context.TicketDesigns, "TicketDesignID", "TicketDesignID", eventTicket.TicketDesignID);
            ViewData["TicketTypeID"] = new SelectList(_context.TicketTypes, "TicketTypeID", "TicketTypeID", eventTicket.TicketTypeID);
            return View(eventTicket);
        }

        // GET: EventTickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventTicket = await _context.EventTickets.SingleOrDefaultAsync(m => m.EventTicketID == id);
            if (eventTicket == null)
            {
                return NotFound();
            }
            ViewData["TicketDesignID"] = new SelectList(_context.TicketDesigns, "TicketDesignID", "TicketDesignID", eventTicket.TicketDesignID);
            ViewData["TicketTypeID"] = new SelectList(_context.TicketTypes, "TicketTypeID", "TicketTypeID", eventTicket.TicketTypeID);
            return View(eventTicket);
        }

        // POST: EventTickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventTicketID,QuantityAvailable,TicketTypeID,TicketDesignID,TicketPrice")] EventTicket eventTicket)
        {
            if (id != eventTicket.EventTicketID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventTicket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventTicketExists(eventTicket.EventTicketID))
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
            ViewData["TicketDesignID"] = new SelectList(_context.TicketDesigns, "TicketDesignID", "TicketDesignID", eventTicket.TicketDesignID);
            ViewData["TicketTypeID"] = new SelectList(_context.TicketTypes, "TicketTypeID", "TicketTypeID", eventTicket.TicketTypeID);
            return View(eventTicket);
        }

        // GET: EventTickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventTicket = await _context.EventTickets
                .Include(e => e.TicketDesign)
                .Include(e => e.TicketType)
                .SingleOrDefaultAsync(m => m.EventTicketID == id);
            if (eventTicket == null)
            {
                return NotFound();
            }

            return View(eventTicket);
        }

        // POST: EventTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventTicket = await _context.EventTickets.SingleOrDefaultAsync(m => m.EventTicketID == id);
            _context.EventTickets.Remove(eventTicket);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EventTicketExists(int id)
        {
            return _context.EventTickets.Any(e => e.EventTicketID == id);
        }
    }
}
