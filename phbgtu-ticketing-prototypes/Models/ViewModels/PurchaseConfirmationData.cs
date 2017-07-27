using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phbgtu_ticketing_prototypes.Models.ViewModels
{
    public class PurchaseConfirmationData
    {


        public IEnumerable<Ticket> Tickets { get; set; }
        public IEnumerable<UserAccount> UserAccounts { get; set; }
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
