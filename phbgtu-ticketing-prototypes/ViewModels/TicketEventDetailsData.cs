using phbgtu_ticketing_prototypes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phbgtu_ticketing_prototypes.ViewModels
{
	public class TicketEventDetailsData
	{
		public Event ticketEvent { get; set; }
        public IEnumerable<EventTicket> eventTickets { get; set; }
    }
}
