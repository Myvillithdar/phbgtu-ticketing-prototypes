using phbgtu_ticketing_prototypes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phbgtu_ticketing_prototypes.ViewModels
{
	public class TicketEventDetailsData
	{
		public TicketEvent ticketEvent { get; set; }
		public IEnumerable<Ticket> tickets { get; set; }
    }
}
