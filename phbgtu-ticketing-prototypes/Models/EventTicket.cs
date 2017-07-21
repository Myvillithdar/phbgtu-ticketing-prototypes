using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace phbgtu_ticketing_prototypes.Models
{
    public class EventTicket
    {
		public int eventTicketID { get; set; }
		public int quantityAvailable { get; set; }
		[Column(TypeName = "money")]
		public decimal Price { get; set; }

		public TicketType ticketType { get; set; }
		public TicketDesign ticketDesign { get; set; }
		public ICollection<Ticket> tickets { get; set; }

		public EventTicket() {

		}
	}
}
