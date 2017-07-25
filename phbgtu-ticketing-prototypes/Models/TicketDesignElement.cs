using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phbgtu_ticketing_prototypes.Models
{
    public class TicketDesignElement
    {
		public int TicketDesignElementID { get; set; }
        public int TicketDesignID { get; set; }
		public string ElementName { get; set; }
		public string ElementType { get; set; }
		public string ElementContent { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public int ZIndex { get; set; }
        public int XDimension { get; set; }
		public int YDimension { get; set; }

		/*
		 * TODO I know xyCoordinates and dimensions are supposed to be arrays,
		 * but the member fields above get stored directly in the database,
		 * so they need to be database-compatible types.  We'll need a getter 
		 * function or something to put the individual numbers together into an
		 * array.
         * 
         * DONE: I changed the names and made them into separate fields,
         * Then I modified the setters and created appropriate getters. (MT)
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
            this.XCoordinate = x;
            this.YCoordinate = y;
        }

        public int[] GetCoordinates()
        {
            int[] coordinates = new int[2];
            coordinates[0] = this.XCoordinate;
            coordinates[1] = this.YCoordinate;
            return coordinates;
        }

        public void SetDimensions(int width, int height)
        {
            this.XDimension = width;
            this.YDimension = height;
        }

        public int[] GetDimensions()
        {
            int[] dimensions = new int[2];
            dimensions[0] = this.XDimension;
            dimensions[1] = this.YDimension;
            return dimensions;
        }
    }
}
