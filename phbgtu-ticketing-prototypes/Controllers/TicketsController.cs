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
using phbgtu_ticketing_prototypes.Models.ViewModels;

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



        public async Task<IActionResult> PurchaseConfirmation1(int? userAccountID) //pass in an ID to find the specific Ticket
        {


            var viewModel = new PurchaseConfirmationData(); //create new instance of the custom ViewModel

            viewModel.account = await _context.UserAccounts
                    .Include(i => i.Tickets)
                    .SingleOrDefaultAsync(m => m.UserAccountID == userAccountID); //where

            //viewModel.


            if (userAccountID == null)
            {
                return NotFound();
            }
            else
            {
                ViewData["UserAcountID"] = userAccountID.Value;

                viewModel.Tickets = viewModel.account.Tickets;//.Select(s => s.Ticket);


                /*
                var selectedUser = viewModel.UserAccounts.Where(x => x.UserAccountID == userAccountID).Single(); //find the entry in the UserAccount table?
                await _context.Entry(selectedUser).Collection(x => x.Tickets).LoadAsync(); //find the Tickets associated with that user?
                foreach (Ticket ticket in selectedUser.Tickets)
                {
                    await _context.Entry(ticket).Reference(x => x.Student).LoadAsync();
                }
                viewModel.Tickets = selectedUser.Tickets;
                */
            }

            return View(viewModel);





            /* //my original code from 3 AM
            

            var viewModel = new PurchaseConfirmationData();

            viewModel.UserAccounts = await _context.UserAccounts
                    .Include(i => i.Tickets)
                  .ToListAsync();

            //viewModel.


            if (userAccountID == null)
            {
                return NotFound();
            }
            else
            {
                ViewData["UserAcountID"] = userAccountID.Value;

                UserAccount user = viewModel.UserAccounts.Where(
                    i => i.UserAccountID == userAccountID.Value).Single(); //find the user who has the userAccountID?
                viewModel.Tickets = user.Tickets//.Select(s => s.Ticket);


                
                //var selectedUser = viewModel.UserAccounts.Where(x => x.UserAccountID == userAccountID).Single(); //find the entry in the UserAccount table?
                //await _context.Entry(selectedUser).Collection(x => x.Tickets).LoadAsync(); //find the Tickets associated with that user?
                //foreach (Ticket ticket in selectedUser.Tickets)
                //{
                //    await _context.Entry(ticket).Reference(x => x.Student).LoadAsync();
                //}
                //viewModel.Tickets = selectedUser.Tickets;
                
        }

            */ 



//*******************************************************************************************

            //other ideas:


            /*//find out the userAcount
            UserAccount = _context.UserAccounts.Include(x => x.Tickets)
                (m => m.EmailAddress.Equals(email));
            */

            //read in from database



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


            /*
             
               var ticket = await _context.Tickets
                .SingleOrDefaultAsync(m => m.TicketID == ID);
            if (ticket == null)
            {
                return NotFound();
            }
    
            */




            //display the ticketID passed in
            //ViewData["Message"] = email;





        }


    }


}
