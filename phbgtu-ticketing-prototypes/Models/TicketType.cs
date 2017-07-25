using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace phbgtu_ticketing_prototypes.Models
{
	public class TicketType
	{
		public int TicketTypeID { get; set; }
		public string TicketTypeName { get; set; }

        [NotMapped]
		public ICollection<EventTicket> EventTickets { get; set; }

	}
}
