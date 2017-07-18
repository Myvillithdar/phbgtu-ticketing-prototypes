using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phbgtu_ticketing_prototypes.Models
{
    public class TicketEvent
    {
        public int TicketEventID { get; set; }
        public string eventName { get; set; }
        public TicketDesign ticketDesign { get; set; }
        public bool ticketSalesEnabled { get; set; }
        public string customMessage { get; set; }
        public DateTime beginSales { get; set; }
        public DateTime endSales { get; set; }

	   public ICollection<Ticket> tickets { get; set; }

        public TicketEvent()
        {

        }


        public string GenerateSalesReport()
        {
            return "";
        }
    }
}
