using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace phbgtu_ticketing_prototypes.Models
{
    public class CustomFormFieldDatatype
    {
        public int CustomFormFieldDatatypeID { get; set; }
        public string DatatypeName { get; set; }

        [NotMapped]
        public IEnumerable<CustomFormFieldQuestion> CustomFormFieldQuestions { get; set; }

        public CustomFormFieldDatatype()
        {

        }
    }
}
