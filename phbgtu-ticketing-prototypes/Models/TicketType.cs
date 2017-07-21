using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace phbgtu_ticketing_prototypes.Models
{
	public class TicketType
	{
		public int TicketTypeID { get; set; }
		public string TicketTypeName { get; set; }

		public ICollection<EventTicket> eventTickets { get; set; }

	}
}
