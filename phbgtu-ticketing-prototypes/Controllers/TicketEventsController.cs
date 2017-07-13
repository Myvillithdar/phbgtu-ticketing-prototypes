﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using phbgtu_ticketing_prototypes.Data;
using phbgtu_ticketing_prototypes.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace phbgtu_ticketing_prototypes.Controllers
{
    public class TicketEventsController : Controller
    {
        private readonly TicketContext _context;

        public TicketEventsController(TicketContext context) {
            _context = context;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            return View(await _context.TicketEvents.ToListAsync());
        }

	   public IActionResult Create()
	   {
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(
			[Bind("ID,ticketSalesEnabled,customMessage,beginSales,endSales")] TicketEvent ticketEvent)
		{
			if (ModelState.IsValid) {
				_context.Add(ticketEvent);
				await _context.SaveChangesAsync();
				return RedirectToAction("Index");
			}
			return View(ticketEvent);
		}

		public async Task<IActionResult> Details(int? id)
		{
			if (id == null) {
				return NotFound();
			}

			var ticketEvent = await _context.TicketEvents
			    .SingleOrDefaultAsync(m => m.TicketEventID == id);
			if (ticketEvent == null) {
				return NotFound();
			}

			return View(ticketEvent);
		}
	}
}
