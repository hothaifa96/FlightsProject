using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights
{
    abstract public  class  FacadeBase
    {
        protected AirlineDAOMSSQL _airlineDAO= new AirlineDAOMSSQL ();
        protected CountryDAOMSSQL _countryDAO= new CountryDAOMSSQL();
        protected CustomerDAOMSSQL _customerDAO= new CustomerDAOMSSQL();
        protected FlightDAOMSSQL _FlightDAO= new FlightDAOMSSQL();
        protected TicketDAOMSSQL _ticketDAO = new TicketDAOMSSQL();        
    }
}
