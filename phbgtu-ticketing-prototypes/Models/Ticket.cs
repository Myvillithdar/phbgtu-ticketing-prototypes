﻿
namespace phbgtu_ticketing_prototypes.Models
{
    public class Ticket
    {
		public int TicketID { get; set; }
		public int TicketTypeID { get; set; }
		public int EventTicketNumber { get; set; }
		public string EventTicketCode { get; set; }

		public int TicketEventID { get; set; }
		public TicketEvent ticketEvent { get; set; }

        public Ticket()
        {
        }
    }
}
