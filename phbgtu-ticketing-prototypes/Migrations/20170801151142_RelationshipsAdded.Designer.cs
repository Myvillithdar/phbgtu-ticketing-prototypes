using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using phbgtu_ticketing_prototypes.Data;

namespace phbgtu_ticketing_prototypes.Migrations
{
    [DbContext(typeof(TicketContext))]
    [Migration("20170801151142_RelationshipsAdded")]
    partial class RelationshipsAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.CustomFormFieldDataOption", b =>
                {
                    b.Property<int>("CustomFormFieldDataOptionID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomFormFieldQuestionID");

                    b.Property<string>("DataOptionValue");

                    b.HasKey("CustomFormFieldDataOptionID");

                    b.HasIndex("CustomFormFieldQuestionID");

                    b.ToTable("CustomFormFieldDataOptions");
                });

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.CustomFormFieldDatatype", b =>
                {
                    b.Property<int>("CustomFormFieldDatatypeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DatatypeName");

                    b.HasKey("CustomFormFieldDatatypeID");

                    b.ToTable("CustomFormFieldDatatypes");
                });

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.CustomFormFieldQuestion", b =>
                {
                    b.Property<int>("CustomFormFieldQuestionID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FormFieldDatatypeID");

                    b.Property<string>("FormFieldLabel");

                    b.Property<bool>("FormFieldRequired");

                    b.Property<int>("TicketDesignID");

                    b.HasKey("CustomFormFieldQuestionID");

                    b.HasIndex("FormFieldDatatypeID");

                    b.HasIndex("TicketDesignID");

                    b.ToTable("CustomFormFieldQuestions");
                });

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.CustomFormFieldResponse", b =>
                {
                    b.Property<int>("CustomFormFieldResponseID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomFormFieldQuestionID");

                    b.Property<string>("FormFieldResponse");

                    b.Property<int>("TicketID");

                    b.HasKey("CustomFormFieldResponseID");

                    b.HasIndex("CustomFormFieldQuestionID");

                    b.ToTable("CustomFormFieldResponses");
                });

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.Event", b =>
                {
                    b.Property<int>("EventID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BeginSales");

                    b.Property<string>("CustomMessage");

                    b.Property<DateTime>("EndSales");

                    b.Property<string>("EventName");

                    b.Property<bool>("TicketSalesEnabled");

                    b.HasKey("EventID");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.EventTicket", b =>
                {
                    b.Property<int>("EventTicketID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AvailableOnline");

                    b.Property<int>("QuantityAvailable");

                    b.Property<int>("TicketDesignID");

                    b.Property<decimal>("TicketPrice");

                    b.Property<int>("TicketTypeID");

                    b.HasKey("EventTicketID");

                    b.HasIndex("TicketDesignID");

                    b.HasIndex("TicketTypeID");

                    b.ToTable("EventTickets");
                });

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.Ticket", b =>
                {
                    b.Property<int>("TicketID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("AmountPaid")
                        .HasColumnType("Money");

                    b.Property<string>("AttendeeName");

                    b.Property<DateTime?>("DateSold")
                        .HasColumnType("Date");

                    b.Property<int>("EventTicketID");

                    b.Property<string>("TicketNumber");

                    b.Property<int>("TicketStatusID");

                    b.Property<int>("UserAccountID");

                    b.HasKey("TicketID");

                    b.HasIndex("EventTicketID");

                    b.HasIndex("TicketStatusID");

                    b.HasIndex("UserAccountID");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.TicketDesign", b =>
                {
                    b.Property<int>("TicketDesignID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DesignDescription");

                    b.Property<string>("DesignName");

                    b.Property<int>("EventID");

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

                    b.Property<int>("TicketDesignID");

                    b.Property<int>("XCoordinate");

                    b.Property<int>("XDimension");

                    b.Property<int>("YCoordinate");

                    b.Property<int>("YDimension");

                    b.Property<int>("ZIndex");

                    b.HasKey("TicketDesignElementID");

                    b.HasIndex("TicketDesignID");

                    b.ToTable("TicketDesignElements");
                });

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.TicketStatus", b =>
                {
                    b.Property<int>("TicketStatusID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TicketStatusName");

                    b.HasKey("TicketStatusID");

                    b.ToTable("TicketStatuses");
                });

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.TicketType", b =>
                {
                    b.Property<int>("TicketTypeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TicketTypeName");

                    b.HasKey("TicketTypeID");

                    b.ToTable("TicketTypes");
                });

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.UserAccount", b =>
                {
                    b.Property<int>("UserAccountID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmailAddress");

                    b.Property<string>("Password");

                    b.Property<string>("PasswordHint");

                    b.Property<string>("UserName");

                    b.Property<int>("UserTypeID");

                    b.HasKey("UserAccountID");

                    b.HasIndex("UserTypeID");

                    b.ToTable("UserAccounts");
                });

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.UserType", b =>
                {
                    b.Property<int>("UserTypeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserTypeName");

                    b.HasKey("UserTypeID");

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.CustomFormFieldDataOption", b =>
                {
                    b.HasOne("phbgtu_ticketing_prototypes.Models.CustomFormFieldQuestion", "CustomFormFieldQuestion")
                        .WithMany()
                        .HasForeignKey("CustomFormFieldQuestionID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.CustomFormFieldQuestion", b =>
                {
                    b.HasOne("phbgtu_ticketing_prototypes.Models.CustomFormFieldDatatype", "FormFieldDatatype")
                        .WithMany("CustomFormFieldQuestions")
                        .HasForeignKey("FormFieldDatatypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("phbgtu_ticketing_prototypes.Models.TicketDesign", "TicketDesign")
                        .WithMany("CustomFormFields")
                        .HasForeignKey("TicketDesignID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.CustomFormFieldResponse", b =>
                {
                    b.HasOne("phbgtu_ticketing_prototypes.Models.CustomFormFieldQuestion", "CustomFormFieldQuestion")
                        .WithMany()
                        .HasForeignKey("CustomFormFieldQuestionID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.EventTicket", b =>
                {
                    b.HasOne("phbgtu_ticketing_prototypes.Models.TicketDesign", "TicketDesign")
                        .WithMany()
                        .HasForeignKey("TicketDesignID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("phbgtu_ticketing_prototypes.Models.TicketType", "TicketType")
                        .WithMany("EventTickets")
                        .HasForeignKey("TicketTypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.Ticket", b =>
                {
                    b.HasOne("phbgtu_ticketing_prototypes.Models.EventTicket", "EventTicket")
                        .WithMany()
                        .HasForeignKey("EventTicketID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("phbgtu_ticketing_prototypes.Models.TicketStatus", "TicketStatus")
                        .WithMany("Tickets")
                        .HasForeignKey("TicketStatusID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("phbgtu_ticketing_prototypes.Models.UserAccount", "UserAccount")
                        .WithMany("Tickets")
                        .HasForeignKey("UserAccountID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.TicketDesign", b =>
                {
                    b.HasOne("phbgtu_ticketing_prototypes.Models.Event", "Event")
                        .WithOne("TicketDesign")
                        .HasForeignKey("phbgtu_ticketing_prototypes.Models.TicketDesign", "EventID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.TicketDesignElement", b =>
                {
                    b.HasOne("phbgtu_ticketing_prototypes.Models.TicketDesign", "TicketDesign")
                        .WithMany()
                        .HasForeignKey("TicketDesignID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("phbgtu_ticketing_prototypes.Models.UserAccount", b =>
                {
                    b.HasOne("phbgtu_ticketing_prototypes.Models.UserType", "UserType")
                        .WithMany("UserAccounts")
                        .HasForeignKey("UserTypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
