using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phbgtu_ticketing_prototypes.Models
{
    public class TicketEvent
    {
        public int ID { get; set; }
        public TicketDesign ticketDesign { get; set; }
        public bool ticketSalesEnabled { get; set; }
        public string customMessage { get; set; }
        public DateTime beginSales { get; set; }
        public DateTime endSales { get; set; }

        public TicketEvent()
        {

        }


        public string GenerateSalesReport()
        {
            return "";
        }
    }
}
