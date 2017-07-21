using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using phbgtu_ticketing_prototypes.Data;

namespace phbgtu_ticketing_prototypes.Migrations
{
    [DbContext(typeof(TicketContext))]
    partial class TicketContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.CustomFormFieldDatatype", b =>
                {
                    b.Property<int>("CustomFormFieldDatatypeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DatatypeName");

                    b.HasKey("CustomFormFieldDatatypeID");

                    b.ToTable("CustomFormFieldDatatype");
                });

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.CustomFormFieldQuestion", b =>
                {
                    b.Property<int>("CustomFormFieldQuestionID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FormFieldDatatypeID");

                    b.Property<string>("FormFieldLabel");

                    b.Property<bool>("FormFieldRequired");

                    b.HasKey("CustomFormFieldQuestionID");

                    b.HasIndex("FormFieldDatatypeID");

                    b.ToTable("CustomFormFields");
                });

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.Event", b =>
                {
                    b.Property<int>("EventID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("beginSales");

                    b.Property<string>("customMessage");

                    b.Property<DateTime>("endSales");

                    b.Property<string>("eventName");

                    b.Property<bool>("ticketSalesEnabled");

                    b.HasKey("EventID");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.EventTicket", b =>
                {
                    b.Property<int>("eventTicketID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<int?>("TicketDesignID");

                    b.Property<int?>("TicketTypeID");

                    b.Property<int>("quantityAvailable");

                    b.HasKey("eventTicketID");

                    b.HasIndex("TicketDesignID");

                    b.HasIndex("TicketTypeID");

                    b.ToTable("EventTickets");
                });

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.Ticket", b =>
                {
                    b.Property<int>("TicketID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EventTicketCode");

                    b.Property<int?>("TicketTypeID");

                    b.Property<string>("attendeeName");

                    b.Property<DateTime>("dateSold");

                    b.Property<int?>("eventTicketID");

                    b.HasKey("TicketID");

                    b.HasIndex("TicketTypeID");

                    b.HasIndex("eventTicketID");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.TicketDesign", b =>
                {
                    b.Property<int>("TicketDesignID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DesignDescription");
                    b.Property<int>("EventID");

                    b.Property<string>("DesignName");

                    b.Property<string>("EventTicketCode");

                    b.HasKey("TicketDesignID");

                    b.HasIndex("EventID")
                        .IsUnique();

                    b.ToTable("TicketDesigns");
                });

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.TicketDesignElement", b =>
                {
                    b.Property<int>("TicketDesignElementID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ElementContent");

                    b.Property<string>("ElementName");

                    b.Property<string>("ElementType");

                    b.Property<int>("XCoordinate");

                    b.Property<int>("XDimension");

                    b.Property<int>("YCoordinate");

                    b.Property<int>("YDimension");

                    b.Property<int>("ZIndex");

                    b.HasKey("TicketDesignElementID");

                    b.ToTable("TicketDesignElements");
                });

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.TicketType", b =>
                {
                    b.Property<int>("TicketTypeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TicketTypeName");

                    b.HasKey("TicketTypeID");

                    b.ToTable("TicketTypes");
                });

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.CustomFormFieldQuestion", b =>
                {
                    b.HasOne("phbgtu_ticketing_prototypes.Models.CustomFormFieldDatatype", "FormFieldDatatype")
                        .WithMany()
                        .HasForeignKey("FormFieldDatatypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.EventTicket", b =>
                {
                    b.HasOne("phbgtu_ticketing_prototypes.Models.TicketDesign", "ticketDesign")
                        .WithMany("eventTickets")
                        .HasForeignKey("TicketDesignID");

                    b.HasOne("phbgtu_ticketing_prototypes.Models.TicketType", "ticketType")
                        .WithMany("eventTickets")
                        .HasForeignKey("TicketTypeID");
                });

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.Ticket", b =>
                {
                    b.HasOne("phbgtu_ticketing_prototypes.Models.TicketType", "ticketType")
                        .WithMany()
                        .HasForeignKey("TicketTypeID");

                    b.HasOne("phbgtu_ticketing_prototypes.Models.EventTicket", "eventTicket")
                        .WithMany("tickets")
                        .HasForeignKey("eventTicketID");
                });

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.TicketDesign", b =>
                {
                    b.HasOne("phbgtu_ticketing_prototypes.Models.Event", "Event")
                        .WithOne("ticketDesign")
                        .HasForeignKey("phbgtu_ticketing_prototypes.Models.TicketDesign", "EventID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.TicketDesignElement", b =>
                {
                    b.HasOne("phbgtu_ticketing_prototypes.Models.TicketDesign")
                        .WithMany("ticketDesignElements")
                        .HasForeignKey("TicketDesignID");
                });
        }
    }
}
