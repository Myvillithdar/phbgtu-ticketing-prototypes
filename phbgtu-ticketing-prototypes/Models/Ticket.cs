using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace phbgtu_ticketing_prototypes.Models
{
    public class Ticket
    {
		public int TicketID { get; set; }
		public int EventTicketID { get; set; }
        public int UserAccountID { get; set; }
        public int TicketStatusID { get; set; }
        [DataType(DataType.Currency)]
	   [Column(TypeName ="Money")]
        public decimal AmountPaid { get; set; }
		[DataType(DataType.Date)]
		[Column(TypeName = "Date")]
		public DateTime? DateSold { get; set; }
		public string AttendeeName { get; set; }
        public string TicketNumber { get; set; }

        [ForeignKey("EventTicketID")]
		public EventTicket EventTicket { get; set; }

        [ForeignKey("UserAccountID")]
		public UserAccount UserAccount { get; set; }

        [ForeignKey("TicketStatusID")]
		public TicketStatus TicketStatus { get; set; }

        public static Random rnd = new Random();

        public Ticket()
        {
        }

        public static string GenerateTicketNumber()
        {
            char[] chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
            int length = 8;

            string randomString = "";

            for (int i = 0; i < length; i++)
            {
                randomString = randomString + chars[rnd.Next(0, chars.Length - 1)];
            }

            return randomString;
        }
    }
}
