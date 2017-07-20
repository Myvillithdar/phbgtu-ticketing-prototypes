using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phbgtu_ticketing_prototypes.Models
{
    public class CustomFormFieldDataOption
    {
        public int CustomFormFieldDataOptionID { get; set; }
        public int CustomFormFieldQuestionID { get; set; }
        public string DataOptionValue { get; set; }

        public CustomFormFieldDataOption()
        {

        }
    }
}
