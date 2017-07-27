using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using phbgtu_ticketing_prototypes.Data;
using phbgtu_ticketing_prototypes.Models;
//add ViewModel signature

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
        public IActionResult Create(int? EventTicketID)
        {
            Ticket ticket = null;
            if (EventTicketID != null)
            {
                ticket = new Ticket();
                ticket.EventTicketID = (int)EventTicketID;
            }

            ViewData["EventTicketID"] = new SelectList(_context.EventTickets, "EventTicketID", "EventTicketID");
            ViewData["TicketStatusID"] = new SelectList(_context.TicketStatuses, "TicketStatusID", "TicketStatusID");
            ViewData["UserAccountID"] = new SelectList(_context.UserAccounts, "UserAccountID", "UserAccountID");
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

        public async Task<IActionResult> Purchase(int id)
        {

            return View();
        }

        private bool TicketExists(int id)
        {
            return _context.Tickets.Any(e => e.TicketID == id);
        }


        public async Task<IActionResult> PurchaseConfirmation(int? ID) //pass in an ID to find the specific Ticket
        {

            //read in from database
            if (ID == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .SingleOrDefaultAsync(m => m.TicketID == ID);
            if (ticket == null)
            {
                return NotFound();
            }



            //display the ticketID passed in
            ViewData["Message"] = ID;

            return View(ticket);



        }



        public async Task<IActionResult> PurchaseConfirmation1(String email) //pass in an ID to find the specific Ticket
        {

            
            if (email == null)
            {
                return NotFound();
            }


            //read in from database
            UserAccount = _context.UserAccounts.Include(x => x.Tickets)
                (m => m.EmailAddress.Equals(email));

            if (userAccountID == null)
            {
                return NotFound();
            }


            //create a view model of user accounts and tickets
            //get copy of user accounts
                //include
            //filter to single results


            //find out what the user acount ID is first
            //based on that user id, look up all the tickets associated with it.
            /*
            var tickets = await _context.Tickets
                .Include(Tickets)
                */

            //(m => email.Equals(m.EmailAddress));

            //make sure something was found before returning it
            if (userAccountID == null)
            {
                return NotFound();
            }

            /*
             
               var ticket = await _context.Tickets
                .SingleOrDefaultAsync(m => m.TicketID == ID);
            if (ticket == null)
            {
                return NotFound();
            }
    
            */




            //display the ticketID passed in
            ViewData["Message"] = email;

            return View(userAccountID);



        }


    }


}
