using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using phbgtu_ticketing_prototypes.Data;
using phbgtu_ticketing_prototypes.Models;

namespace phbgtu_ticketing_prototypes.Controllers
{
	public class TicketEventController : Controller
    {
	    
        private readonly TicketContext _context;

		public TicketEventController(TicketContext context)
		{
			_context = context;
		}

			// GET: /<controller>/
			public IActionResult Index()
			{
				return View();
			}

			
    

    }
}



/*

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using phbgtu_ticketing_prototypes.Data;
using phbgtu_ticketing_prototypes.Models;

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
    }
}

*/
