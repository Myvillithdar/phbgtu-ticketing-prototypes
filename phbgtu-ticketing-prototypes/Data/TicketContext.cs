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
		public DbSet<EventTicket> EventTickets { get; set; }
		public DbSet<TicketType> TicketTypes { get; set; }
        public DbSet<TicketEvent> TicketEvents { get; set; }
	    public DbSet<CustomFormFieldQuestion> CustomFormFieldQuestions { get; set; }
	    public DbSet<TicketDesign> TicketDesigns { get; set; }
	    public DbSet<TicketDesignElement> TicketDesignElements { get; set; }
        public DbSet<CustomFormFieldDatatype> CustomFormFieldDatatypes { get; set; }
        public DbSet<CustomFormFieldDataOption> CustomFormFieldDataOptions{ get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<UserType> UserTypes{ get; set; }
        public DbSet<TicketStatus> TicketStatuses { get; set; }
        public DbSet<CustomFormFieldResponse> CustomFormFieldResponses { get; set; }
		public DbSet<Event> Events { get; set; }
    }
}
