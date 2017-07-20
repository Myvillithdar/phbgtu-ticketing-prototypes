
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using phbgtu_ticketing_prototypes.Data;
using phbgtu_ticketing_prototypes.Models;
using Microsoft.AspNetCore.Routing;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace phbgtu_ticketing_prototypes.Controllers
{
    public class TicketsController : Controller
    {
		private readonly TicketContext _context;

		public TicketsController(TicketContext context) {
			_context = context;
		}

		// GET: /<controller>/
		public async Task<IActionResult> Index()
        {
            return View(await _context.Tickets.ToListAsync());
        }
        public IActionResult Purchase()
        {
            return View();
		}

        public IActionResult PurchaseConfirmation(int ticketID) //pass in an ID to find the specific Ticket
        {

            //read in from database

            ViewData["Message"] =  ticketID;

            return View();
        }


		/*public IActionResult Create()
		{
			return View();
		}*/

		public async Task<IActionResult> Details(int? id)
		{
			if (id == null) {
				return NotFound();
			}

			var ticket = await _context.Tickets
			    .SingleOrDefaultAsync(m => m.TicketID == id);
			if (ticket == null) {
				return NotFound();
			}

			return View(ticket);
		}

		public async Task<IActionResult> Create(int? id)
		{
			if (id == null) {
				return NotFound();
			}

			Ticket ticket = new Ticket();
			ticket.TicketEventID = id.Value;
			ticket.EventTicketNumber = 33; //TODO fix this
			ticket.EventTicketCode = "AZ6"; //TODO fix this
			_context.Add(ticket);
			_context.SaveChanges();
			return RedirectToAction("Details", "TicketEvents", new { id = id });
		}
	}
}
