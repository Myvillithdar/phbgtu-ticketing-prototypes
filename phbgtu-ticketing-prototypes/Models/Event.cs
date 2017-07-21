using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace phbgtu_ticketing_prototypes.Models
{
	public class Event
	{
		public int EventID { get; set; }
		public string EventName { get; set; }
		public bool TicketSalesEnabled { get; set; }
		public string CustomMessage { get; set; }
		public DateTime BeginSales { get; set; }
		public DateTime EndSales { get; set; }

        [NotMapped]
		public TicketDesign TicketDesign { get; set; }

		public Event()
		{

		}

		public string GenerateSalesReport()
		{
			return "";
		}
	}
}
