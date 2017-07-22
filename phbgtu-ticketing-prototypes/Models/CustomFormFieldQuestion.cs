using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace phbgtu_ticketing_prototypes.Models
{
    public class CustomFormFieldQuestion
    {
		public int CustomFormFieldQuestionID { get; set; }
        public int TicketDesignID { get; set; }
		public string FormFieldLabel { get; set; }
		public int FormFieldDatatypeID { get; set; }
		public bool FormFieldRequired { get; set; }

        [ForeignKey("FormFieldDatatypeID")]
        public CustomFormFieldDatatype FormFieldDatatype { get; set; }

        [NotMapped]
        public IEnumerable<CustomFormFieldDataOption> FormFieldDataOptions { get; set; }

		public CustomFormFieldQuestion()
		{

		}
    }
}
