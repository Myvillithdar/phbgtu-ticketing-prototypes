using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phbgtu_ticketing_prototypes.Models
{
    public class CustomFormField
    {
		public int CustomFormFieldID { get; set; }
		public string formFieldLabel { get; set; }
		public string formFiledDataType { get; set; }
		public bool formFieldRequired { get; set; }

		public CustomFormField()
		{

		}
    }
}
