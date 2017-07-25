using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace phbgtu_ticketing_prototypes.Models
{
    public class EventTicket
    {
		public int EventTicketID { get; set; }
		public int QuantityAvailable { get; set; }
        public int TicketTypeID { get; set; }
        public int TicketDesignID { get; set; }

		[DataType(DataType.Currency)]
		public decimal TicketPrice { get; set; }

        [ForeignKey("TicketTypeID")]
		public TicketType TicketType { get; set; }

        [ForeignKey("TicketDesignID")]
		public TicketDesign TicketDesign { get; set; }

        [NotMapped]
		public ICollection<Ticket> Tickets { get; set; }

		public EventTicket() {

		}
	}
}
