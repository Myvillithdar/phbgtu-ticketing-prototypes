﻿using Microsoft.EntityFrameworkCore;
using phbgtu_ticketing_prototypes.Models;

namespace phbgtu_ticketing_prototypes.Data
{
    public class TicketContext : DbContext
    {
		public TicketContext(DbContextOptions<TicketContext> options) : base(options)
		{
		}

		public DbSet<Ticket> Tickets { get; set; }
		public DbSet<TicketType> TicketTypes { get; set; }
    }
}
