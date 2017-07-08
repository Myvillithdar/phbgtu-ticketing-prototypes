using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phbgtu_ticketing_prototypes.Models
{
    public class TicketEvent
    {
        private TicketDesign ticketDesign;
        private bool ticketSalesEnabled;
        private string customMessage;
        private DateTime beginSales;
        private DateTime endSales;

        public TicketEvent()
        {

        }


        public string GenerateSalesReport()
        {
            return "";
        }
    }
}
