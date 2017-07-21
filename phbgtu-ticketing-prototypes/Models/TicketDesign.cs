using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phbgtu_ticketing_prototypes.Models
{
    public class TicketDesign
    {
		public int TicketDesignID { get; set; }
		public string ticketDesignName { get; set; }
		public string ticketDesignDescription { get; set; }

		public int EventID { get; set; }
		public Event Event { get; set; }
		public ICollection<EventTicket> eventTickets { get; set; }
		public ICollection<TicketDesignElement> ticketDesignElements { get; set; }
		public ICollection<CustomFormField> customFormFields { get; set; }

		public TicketDesign()
	    {

	    }


	    public void DoLayout()
	    {

	    }

	    public void SetBackGround()
	    {

	    }

	    public TicketDesignElement[] GetTicketDesignElements()
	    {
		   return new TicketDesignElement[1];
	    }

	    public void UpdateTicketDesignElement()
	    {

	    }

	    public void UpdateCustomFormField()
	    {

	    }
	}
}
