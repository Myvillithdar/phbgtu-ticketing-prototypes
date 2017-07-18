using Microsoft.EntityFrameworkCore;
using phbgtu_ticketing_prototypes.Models;

namespace phbgtu_ticketing_prototypes.Data
{
    public class TicketContext : DbContext
    {
		public TicketContext(DbContextOptions<TicketContext> options) : base(options)
		{
		}

		public TicketContext() {

		}

		public DbSet<Ticket> Tickets { get; set; }
		public DbSet<TicketType> TicketTypes { get; set; }
		public DbSet<TicketEvent> TicketEvents { get; set; }
		public DbSet<CustomFormField> CustomFormFields { get; set; }
		public DbSet<TicketDesign> TicketDesigns { get; set; }
		public DbSet<TicketDesignElement> TicketDesignElements { get; set; }
    }
}
