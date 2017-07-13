using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phbgtu_ticketing_prototypes.Models
{
    public class TicketDesignElement
    {
		public int TicketDesignElementID { get; set; }
		public string elementName { get; set; }
		public string elementType { get; set; }
		public string elementContent { get; set; }
		public int xyCoordinates { get; set; }
		public int zIndex { get; set; }
		public int dimensions { get; set; }

		/*
		 * TODO I know xyCoordinates and dimensions are supposed to be arrays,
		 * but the member fields above get stored directly in the database,
		 * so they need to be database-compatible types.  We'll need a getter 
		 * function or something to put the individual numbers together into an
		 * array.
		 */

		public TicketDesignElement()
        {

        }

        /// <summary>
        /// Loads the ticket design element from the database
        /// </summary>
        public void GetTicketDesignElement()
        {

        }
        public void UpdateTicketDesignElement()
        {

        }

        public void SetCoordinates(int x, int y)
        {
        //    this.xyCoordinates = new int[2] { x, y };
        }

        public void SetDimensions(int length, int width)
        {
        //    this.dimensions = new int[2] { length, width };
        }
    }
}
