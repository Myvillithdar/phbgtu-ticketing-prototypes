using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phbgtu_ticketing_prototypes.Models
{
    public class TicketDesign
    {
    private string designName;
    private string designDescription;
    private TicketDesignElement[] elements;
    private String eventTicketCode;
    private CustomFormField[] customFormFields;

    public TicketDesign()
    {

    }


    public void DoLayout()
    {

    }

    public void SetBackGround()
    {

    }

    public TicketDesignElement[] GetTicketDesignElements()
    {
        return new TicketDesignElement[1];
    }

    public void UpdateTicketDesignElement()
    {

    }

    public void UpdateCustomFormField()
    {

    }
}
}
