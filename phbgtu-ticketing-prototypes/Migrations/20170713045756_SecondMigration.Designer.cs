using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using phbgtu_ticketing_prototypes.Data;

namespace phbgtu_ticketing_prototypes.Migrations
{
    [DbContext(typeof(TicketContext))]
    [Migration("20170713045756_SecondMigration")]
    partial class SecondMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.CustomFormField", b =>
                {
                    b.Property<int>("CustomFormFieldID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("TicketDesignID");

                    b.Property<string>("formFieldLabel");

                    b.Property<bool>("formFieldRequired");

                    b.Property<string>("formFiledDataType");

                    b.HasKey("CustomFormFieldID");

                    b.HasIndex("TicketDesignID");

                    b.ToTable("CustomFormFields");
                });

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

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.TicketDesign", b =>
                {
                    b.Property<int>("TicketDesignID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("designDescription");

                    b.Property<string>("designName");

                    b.Property<string>("eventTicketCode");

                    b.HasKey("TicketDesignID");

                    b.ToTable("TicketDesigns");
                });

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.TicketDesignElement", b =>
                {
                    b.Property<int>("TicketDesignElementID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("TicketDesignID");

                    b.Property<int>("dimensions");

                    b.Property<string>("elementContent");

                    b.Property<string>("elementName");

                    b.Property<string>("elementType");

                    b.Property<int>("xyCoordinates");

                    b.Property<int>("zIndex");

                    b.HasKey("TicketDesignElementID");

                    b.HasIndex("TicketDesignID");

                    b.ToTable("TicketDesignElements");
                });

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.TicketEvent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("TicketDesignID");

                    b.Property<DateTime>("beginSales");

                    b.Property<string>("customMessage");

                    b.Property<DateTime>("endSales");

                    b.Property<bool>("ticketSalesEnabled");

                    b.HasKey("ID");

                    b.HasIndex("TicketDesignID");

                    b.ToTable("TicketEvents");
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

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.CustomFormField", b =>
                {
                    b.HasOne("phbgtu_ticketing_prototypes.Models.TicketDesign")
                        .WithMany("customFormFields")
                        .HasForeignKey("TicketDesignID");
                });

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.Ticket", b =>
                {
                    b.HasOne("phbgtu_ticketing_prototypes.Models.TicketType")
                        .WithMany("Tickets")
                        .HasForeignKey("TicketTypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.TicketDesignElement", b =>
                {
                    b.HasOne("phbgtu_ticketing_prototypes.Models.TicketDesign")
                        .WithMany("elements")
                        .HasForeignKey("TicketDesignID");
                });

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.TicketEvent", b =>
                {
                    b.HasOne("phbgtu_ticketing_prototypes.Models.TicketDesign", "ticketDesign")
                        .WithMany()
                        .HasForeignKey("TicketDesignID");
                });
        }
    }
}
