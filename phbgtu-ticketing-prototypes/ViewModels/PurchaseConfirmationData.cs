using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using phbgtu_ticketing_prototypes.Models;

namespace phbgtu_ticketing_prototypes.ViewModels
{
    public class PurchaseConfirmationData
    {

        
        public IEnumerable<Ticket> Tickets { get; set; }
        public UserAccount account { get; set; }
        public decimal totalPrice { get; set; }
        public List<CustomFormFieldQuestion> questions { get; set; }
        public Event Event { get; set; }
        
        /*
        public int TicketID { get; set; }
        public int EventTicketID { get; set; }
        public int UserAccountID { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime? DateSold { get; set; }
        public string AttendeeName { get; set; }
        public string TicketNumber { get; set; }
        */

    }
}
