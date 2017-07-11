using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using phbgtu_ticketing_prototypes.Data;

namespace phbgtu_ticketing_prototypes.Migrations
{
    [DbContext(typeof(TicketContext))]
    [Migration("20170711151119_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.Ticket", b =>
                {
                    b.Property<int>("TicketID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EventTicketCode");

                    b.Property<int>("EventTicketNumber");

                    b.Property<int>("TicketTypeID");

                    b.HasKey("TicketID");

                    b.HasIndex("TicketTypeID");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.TicketType", b =>
                {
                    b.Property<int>("TicketTypeID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EventID");

                    b.Property<int>("TicketTypeLimit");

                    b.Property<string>("TicketTypeName");

                    b.HasKey("TicketTypeID");

                    b.ToTable("TicketTypes");
                });

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.Ticket", b =>
                {
                    b.HasOne("phbgtu_ticketing_prototypes.Models.TicketType")
                        .WithMany("Tickets")
                        .HasForeignKey("TicketTypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
