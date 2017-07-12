using Microsoft.EntityFrameworkCore;

namespace phbgtu_ticketing_prototypes.Models
{
    public class phbgtu_ticketing_prototypes_Context : DbContext
    {
        public phbgtu_ticketing_prototypes_Context(DbContextOptions<phbgtu_ticketing_prototypes_Context> options)
            : base (options)
        {
        }

        public DbSet<phbgtu_ticketing_prototypes.Models.TicketEvent> TicketEvent { get; set; }

    }
}
