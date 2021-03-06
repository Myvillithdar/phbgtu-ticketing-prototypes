﻿using System;
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
    public class EventsController : Controller
    {
        private readonly TicketContext _context;

        public EventsController(TicketContext context)
        {
            _context = context;    
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            return View(await _context.Events.ToListAsync());
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = new TicketEventDetailsData();
            viewModel.ticketEvent = await _context.Events
                .SingleOrDefaultAsync(m => m.EventID == id);
            TicketDesign td = await _context.TicketDesigns.SingleOrDefaultAsync(m => m.EventID == id);
            viewModel.eventTickets = await _context.EventTickets.Where(m => m.TicketDesignID == td.TicketDesignID).ToListAsync();

		  viewModel.tickets = new List<Ticket>();
		  foreach (EventTicket et in viewModel.eventTickets) {
				List<Ticket> tickets = await _context.Tickets.Where(m => m.EventTicketID == et.EventTicketID).ToListAsync();
				foreach (Ticket t in tickets) {
					t.UserAccount = await _context.UserAccounts.SingleOrDefaultAsync(m => m.UserAccountID == t.UserAccountID);
					t.TicketStatus = await _context.TicketStatuses.SingleOrDefaultAsync(m => m.TicketStatusID == t.TicketStatusID);
					((List<Ticket>)viewModel.tickets).Add(t);
				}
				et.QuantitySold = tickets.Count();
				et.QuantityRemaining = et.QuantityAvailable - et.QuantitySold;
			}

		  foreach (var et in viewModel.eventTickets) {
				et.TicketType = await _context.TicketTypes.SingleOrDefaultAsync(m => m.TicketTypeID == et.TicketTypeID);
		  }

            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            return View();
        }

		// POST: Events/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("EventID,EventName,CustomMessage,BeginSales,EndSales")] Event @event)
		{
			if (ModelState.IsValid)
			{
				TicketDesign td = new TicketDesign();
				td.DesignName = @event.EventName;
				td.DesignDescription = @event.CustomMessage;
				_context.Add(@event);
				_context.SaveChanges();
				td.EventID = @event.EventID;
				_context.Add(td);
				await _context.SaveChangesAsync();
				return RedirectToAction("Index");
			}
			return View(@event);
		}

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events.SingleOrDefaultAsync(m => m.EventID == id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventID,EventName,TicketSalesEnabled,CustomMessage,BeginSales,EndSales")] Event @event)
        {
            if (id != @event.EventID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.EventID))
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
            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .SingleOrDefaultAsync(m => m.EventID == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Events.SingleOrDefaultAsync(m => m.EventID == id);
            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.EventID == id);
        }
    }
}
