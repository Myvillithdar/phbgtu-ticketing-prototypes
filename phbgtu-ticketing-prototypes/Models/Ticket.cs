using System;
using System.ComponentModel.DataAnnotations;

namespace phbgtu_ticketing_prototypes.Models
{
    public class Ticket
    {
		public int TicketID { get; set; }
		[DataType(DataType.Date)]
		public DateTime dateSold { get; set; }
		public string EventTicketCode { get; set; }
		public string attendeeName { get; set; }

//		public UserAccount userAccount { get; set; }
//		public TicketStatus ticketStatus { get; set; }
		public EventTicket eventTicket { get; set; }
		public TicketType ticketType { get; set; }

        public Ticket()
        {
        }
    }
}
