using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace phbgtu_ticketing_prototypes.Models
{
    public class TicketDesign
    {
		public int TicketDesignID { get; set; }
		public int EventID { get; set; }
		public string DesignName { get; set; }
		public string DesignDescription { get; set; }
		public String EventTicketCode { get; set; }

        [ForeignKey("EventID")]
		public Event Event { get; set; }

        [NotMapped]
		public IEnumerable<TicketDesignElement> Elements { get; set; }

        [NotMapped]
		public IEnumerable<CustomFormFieldQuestion> CustomFormFields { get; set; }

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
