using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using phbgtu_ticketing_prototypes.Data;
using phbgtu_ticketing_prototypes.Models;
using phbgtu_ticketing_prototypes.ViewModels;

namespace phbgtu_ticketing_prototypes.Controllers
{
    public class TicketsController : Controller
    {
        private readonly TicketContext _context;

        public TicketsController(TicketContext context)
        {
            _context = context;    
        }

        // GET: Tickets
        public async Task<IActionResult> Index()
        {
            var ticketContext = _context.Tickets.Include(t => t.EventTicket).Include(t => t.TicketStatus).Include(t => t.UserAccount);
            return View(await ticketContext.ToListAsync());
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .Include(t => t.EventTicket)
                .Include(t => t.TicketStatus)
                .Include(t => t.UserAccount)
                .SingleOrDefaultAsync(m => m.TicketID == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Tickets/Create
        public async Task<IActionResult> Create(int? EventTicketID)
        {
            Ticket ticket = null;
            EventTicket eventTicket = null;
            if (EventTicketID != null)
            {
                ticket = new Ticket();
                ticket.EventTicketID = (int)EventTicketID;
                eventTicket = await _context.EventTickets.SingleOrDefaultAsync(m => m.EventTicketID == EventTicketID);
            }

            // load the ticket type names into the event tickets.
            var eventTickets = await _context.EventTickets.ToListAsync();
            for (int i = 0; i < eventTickets.Count(); i++)
            {
                eventTickets.ElementAt(i).TicketType = await _context.TicketTypes
                        .SingleOrDefaultAsync(m => m.TicketTypeID == eventTickets.ElementAt(i).TicketTypeID);
            }

            ViewData["EventTicketID"] = new SelectList(_context.EventTickets, "EventTicketID", "TicketType.TicketTypeName", eventTicket);
            ViewData["TicketStatusID"] = new SelectList(_context.TicketStatuses, "TicketStatusID", "TicketStatusName");
            ViewData["UserAccountID"] = new SelectList(_context.UserAccounts, "UserAccountID", "UserName");
            return View(ticket);
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TicketID,EventTicketID,UserAccountID,TicketStatusID,AmountPaid,DateSold,AttendeeName,TicketNumber")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["EventTicketID"] = new SelectList(_context.EventTickets, "EventTicketID", "EventTicketID", ticket.EventTicketID);
            ViewData["TicketStatusID"] = new SelectList(_context.TicketStatuses, "TicketStatusID", "TicketStatusID", ticket.TicketStatusID);
            ViewData["UserAccountID"] = new SelectList(_context.UserAccounts, "UserAccountID", "UserAccountID", ticket.UserAccountID);
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets.SingleOrDefaultAsync(m => m.TicketID == id);
            if (ticket == null)
            {
                return NotFound();
            }
            ViewData["EventTicketID"] = new SelectList(_context.EventTickets, "EventTicketID", "EventTicketID", ticket.EventTicketID);
            ViewData["TicketStatusID"] = new SelectList(_context.TicketStatuses, "TicketStatusID", "TicketStatusID", ticket.TicketStatusID);
            ViewData["UserAccountID"] = new SelectList(_context.UserAccounts, "UserAccountID", "UserAccountID", ticket.UserAccountID);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TicketID,EventTicketID,UserAccountID,TicketStatusID,AmountPaid,DateSold,AttendeeName,TicketNumber")] Ticket ticket)
        {
            if (id != ticket.TicketID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.TicketID))
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
            ViewData["EventTicketID"] = new SelectList(_context.EventTickets, "EventTicketID", "EventTicketID", ticket.EventTicketID);
            ViewData["TicketStatusID"] = new SelectList(_context.TicketStatuses, "TicketStatusID", "TicketStatusID", ticket.TicketStatusID);
            ViewData["UserAccountID"] = new SelectList(_context.UserAccounts, "UserAccountID", "UserAccountID", ticket.UserAccountID);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .Include(t => t.EventTicket)
                .Include(t => t.TicketStatus)
                .Include(t => t.UserAccount)
                .SingleOrDefaultAsync(m => m.TicketID == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _context.Tickets.SingleOrDefaultAsync(m => m.TicketID == id);
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // POST: Save Ticket
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveTicket([Bind("TicketID,EventTicketID,UserAccountID,TicketStatusID,AmountPaid,DateSold,AttendeeName,TicketNumber")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction("PurchaseConfirmation");
            }

            ViewData["EventTicketID"] = new SelectList(_context.EventTickets, "EventTicketID", "EventTicketID", ticket.EventTicketID);
            ViewData["TicketStatusID"] = new SelectList(_context.TicketStatuses, "TicketStatusID", "TicketStatusID", ticket.TicketStatusID);
            ViewData["UserAccountID"] = new SelectList(_context.UserAccounts, "UserAccountID", "UserAccountID", ticket.UserAccountID);
            return View(ticket);
        }

        // GET: Tickets/Purchase/5
        // the ID is the EventID
        public async Task<IActionResult> Purchase(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EventTicketPurchaseData viewModel = new EventTicketPurchaseData();

            viewModel.Event = await _context.Events.SingleOrDefaultAsync(m => m.EventID == id);
            viewModel.TicketDesign = await _context.TicketDesigns.SingleOrDefaultAsync(m => m.EventID == id);
            viewModel.EventTickets = await _context.EventTickets
                .Where(m => m.TicketDesignID == viewModel.TicketDesign.TicketDesignID).ToListAsync();
            
            for (int i = 0; i < viewModel.EventTickets.Count(); i++)
            {
                viewModel.EventTickets.ElementAt(i).TicketType = await _context.TicketTypes
                    .SingleOrDefaultAsync(m => m.TicketTypeID == viewModel.EventTickets.ElementAt(i).TicketTypeID);
            }

            return View(viewModel);
        }

        // POST: Tickets/Purchase
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Purchase(List<Ticket> tickets, int userAccountID, int[] ticketQuantity)
        {
            int ticketStatusID = (await _context.TicketStatuses
                .SingleOrDefaultAsync(m => m.TicketStatusName == "Sold")).TicketStatusID;

            Ticket ticket;
            Ticket newTicket;
            EventTicket eventTicket;
            DateTime dateSold = DateTime.Now;

            for (int i = 0; i < tickets.Count(); i++)
            {
                ticket = tickets.ElementAt(i);
                eventTicket = await _context.EventTickets.SingleOrDefaultAsync(m => m.EventTicketID == ticket.EventTicketID);

                for (int j = 0; j < ticketQuantity[i]; j++)
                {
                    /* make a quantity loop here that will create new ticket objects,
                     * assign them their values, then add them to the DB context.
                     * After the loop, save changes to the DB context.
                    */
                    newTicket = new Ticket();
                    newTicket.UserAccountID = userAccountID;
                    newTicket.TicketStatusID = ticketStatusID;
                    newTicket.EventTicketID = eventTicket.EventTicketID;
                    newTicket.AmountPaid = eventTicket.TicketPrice;
                    newTicket.DateSold = dateSold;
                    newTicket.AttendeeName = "";
                    newTicket.TicketNumber = Ticket.GenerateTicketNumber();
                    _context.Add(newTicket);
                }
            }

            await _context.SaveChangesAsync();

            // change to something like this: return PurchaseConfirmation1(userAccountID);
            return RedirectToAction("PurchaseConfirmation1/" + userAccountID);
        }

        private bool TicketExists(int id)
        {
            return _context.Tickets.Any(e => e.TicketID == id);
        }
    }
}
