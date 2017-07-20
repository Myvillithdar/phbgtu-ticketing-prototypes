using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using phbgtu_ticketing_prototypes.Data;

namespace phbgtu_ticketing_prototypes.Migrations
{
    [DbContext(typeof(TicketContext))]
    [Migration("20170720222707_CustomFormField-Data-and-Responses")]
    partial class CustomFormFieldDataandResponses
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.Ticket", b =>
                {
                    b.Property<int>("TicketID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EventTicketCode");

                    b.Property<int>("EventTicketNumber");

                    b.Property<int>("TicketEventID");

                    b.Property<int?>("TicketTypeID");

                    b.HasKey("TicketID");

                    b.HasIndex("TicketEventID");

                    b.HasIndex("TicketTypeID");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.TicketDesign", b =>
                {
                    b.Property<int>("TicketDesignID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DesignDescription");

                    b.Property<string>("DesignName");

                    b.Property<string>("EventTicketCode");

                    b.HasKey("TicketDesignID");

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

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.TicketEvent", b =>
                {
                    b.Property<int>("TicketEventID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("TicketDesignID");

                    b.Property<DateTime>("beginSales");

                    b.Property<string>("customMessage");

                    b.Property<DateTime>("endSales");

                    b.Property<bool>("ticketSalesEnabled");

                    b.HasKey("TicketEventID");

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

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.CustomFormFieldQuestion", b =>
                {
                    b.HasOne("phbgtu_ticketing_prototypes.Models.CustomFormFieldDatatype", "FormFieldDatatype")
                        .WithMany()
                        .HasForeignKey("FormFieldDatatypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.Ticket", b =>
                {
                    b.HasOne("phbgtu_ticketing_prototypes.Models.TicketEvent", "ticketEvent")
                        .WithMany("tickets")
                        .HasForeignKey("TicketEventID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("phbgtu_ticketing_prototypes.Models.TicketType")
                        .WithMany("Tickets")
                        .HasForeignKey("TicketTypeID");
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
