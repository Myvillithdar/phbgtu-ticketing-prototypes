using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phbgtu_ticketing_prototypes.Models
{
    public class TicketDesignElement
    {
        private string elementName;
        private string elementType;
        private string elementContent;
        private int[] xyCoordinates;
        private int zIndex;
        private int[] dimensions;

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
            this.xyCoordinates = new int[2] { x, y };
        }

        public void SetDimensions(int length, int width)
        {
            this.dimensions = new int[2] { length, width };
        }
    }
}
