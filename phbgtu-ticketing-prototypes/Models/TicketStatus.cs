using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace phbgtu_ticketing_prototypes.Models
{
    public class TicketStatus
    {
        public int TicketStatusID { get; set; }
        public string TicketStatusName { get; set; }

        [NotMapped]
        public ICollection<Ticket> Tickets { get; set; }

        public TicketStatus()
        {

        }
    }
}
