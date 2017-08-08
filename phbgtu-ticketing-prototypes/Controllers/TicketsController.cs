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
                .Where(m => m.TicketDesignID == viewModel.TicketDesign.TicketDesignID)
                .Where(m => m.AvailableOnline == true)
                .ToListAsync();
            
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


        public async Task<IActionResult> PurchaseConfirmationOriginal(int? ID) //pass in an ID to find the specific Ticket
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


        /*
            
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


        */

        public async Task<IActionResult> PurchaseConfirmation(int? userAccountID) //pass in an ID to find the specific Ticket
        {


            if (userAccountID == null)
            {
                return NotFound();
            }

            ViewData["UserAcountID"] = userAccountID.Value;

            PurchaseConfirmationData viewModel = new PurchaseConfirmationData(); //create new instance of the custom ViewModel

            viewModel.account = await _context.UserAccounts //find the specific user acount based on the userAccountID passed in
                    .SingleOrDefaultAsync(m => m.UserAccountID == userAccountID); //where

            viewModel.Tickets = await _context.Tickets.Include(t => t.EventTicket)  //copy tickets from the account to the viewModel Tickets
                .Where(m => m.UserAccountID == viewModel.account.UserAccountID).ToListAsync();


            for (int i = 0; i < viewModel.Tickets.Count(); i++)
            {
                viewModel.Tickets.ElementAt(i).EventTicket.TicketType = await _context.TicketTypes
                    .SingleOrDefaultAsync(m => m.TicketTypeID == viewModel.Tickets.ElementAt(i).EventTicket.TicketTypeID); //where

                viewModel.Tickets.ElementAt(i).CustomFormFieldResponses = await _context.CustomFormFieldResponses
                    .Where(m => m.TicketID == viewModel.Tickets.ElementAt(i).TicketID).Include(t => t.CustomFormFieldQuestion).ToListAsync();

            }


            return View(viewModel);



            /*
            var selectedUser = viewModel.UserAccounts.Where(x => x.UserAccountID == userAccountID).Single(); //find the entry in the UserAccount table?
            await _context.Entry(selectedUser).Collection(x => x.Tickets).LoadAsync(); //find the Tickets associated with that user?
            foreach (Ticket ticket in selectedUser.Tickets)
            {
                await _context.Entry(ticket).Reference(x => x.Student).LoadAsync();
            }
            viewModel.Tickets = selectedUser.Tickets;
            */

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
