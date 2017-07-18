using System.Collections.Generic;

namespace phbgtu_ticketing_prototypes.Models
{
	public class TicketType
	{
		public int TicketTypeID { get; set; }
		public int EventID { get; set; }
		public string TicketTypeName { get; set; }
		public int TicketTypeLimit { get; set; }
		//TODO how to set up a money field?

		public ICollection<Ticket> Tickets { get; set; }
		public TicketEvent ticketEvent { get; set; }

	}
}
