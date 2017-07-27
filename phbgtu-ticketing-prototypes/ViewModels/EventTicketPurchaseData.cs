using phbgtu_ticketing_prototypes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phbgtu_ticketing_prototypes.ViewModels
{
    public class EventTicketPurchaseData
    {
        public Event Event { get; set; }
        public TicketDesign TicketDesign { get; set; }
        public IEnumerable<EventTicket> EventTickets { get; set; }
    }
}
