using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace phbgtu_ticketing_prototypes.Models
{
	public class TicketType
	{
		public int TicketTypeID { get; set; }
		public int EventID { get; set; }
		public string TicketTypeName { get; set; }
		public int TicketTypeLimit { get; set; }
		[Column(TypeName="money")]
		public decimal Price { get; set; }

		public ICollection<Ticket> Tickets { get; set; }
		public TicketEvent ticketEvent { get; set; }

	}
}
