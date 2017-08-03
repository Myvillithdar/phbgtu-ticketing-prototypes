using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace phbgtu_ticketing_prototypes.Models
{
    public class CustomFormFieldResponse
    {
        public int CustomFormFieldResponseID { get; set; }
        public int TicketID { get; set; }
        public int CustomFormFieldQuestionID { get; set; }
        public string FormFieldResponse { get; set; }

        [ForeignKey("CustomFormFieldQuestionID")]
        public CustomFormFieldQuestion CustomFormFieldQuestion { get; set; }

        public CustomFormFieldResponse()
        {

        }
    }
}
