using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using phbgtu_ticketing_prototypes.Data;
using phbgtu_ticketing_prototypes.Models;
using phbgtu_ticketing_prototypes.ViewModels;
using System.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace phbgtu_ticketing_prototypes.Controllers
{
    public class EventsController : Controller
    {
        private readonly TicketContext _context;

        public EventsController(TicketContext context) {
            _context = context;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            return View(await _context.Events.ToListAsync());
        }

	   public IActionResult Create()
	   {
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(
			[Bind("ID,ticketSalesEnabled,customMessage,beginSales,endSales")] Event ticketEvent)
		{
			if (ModelState.IsValid) {
				_context.Add(ticketEvent);
				await _context.SaveChangesAsync();
				return RedirectToAction("Index");
			}
			return View(ticketEvent);
		}

		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null) {
				return NotFound();
			}

			Event model = await _context.Events.SingleOrDefaultAsync(m => m.EventID == id);

			return View(model);
		}

		public async Task<IActionResult> Details(int? id)
		{
			if (id == null) {
				return NotFound();
			}

			var viewModel = new TicketEventDetailsData();
//			viewModel.ticketEvent = await _context.Events
//				.Include(e => e.tickets)
//				.SingleOrDefaultAsync(m => m.TicketEventID == id);

			if (viewModel.ticketEvent == null) {
				return NotFound();
			}

//			viewModel.tickets = viewModel.ticketEvent.tickets;

			return View(viewModel);
		}
	}
}
