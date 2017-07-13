using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phbgtu_ticketing_prototypes.Models
{
    public class TicketDesign
    {
		public int TicketDesignID { get; set; }
		public string designName { get; set; }
		public string designDescription { get; set; }
		public TicketDesignElement[] elements { get; set; }
		public String eventTicketCode { get; set; }
		public CustomFormField[] customFormFields { get; set; }

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
