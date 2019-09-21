using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights
{
    public interface  ILoggedInCustomerFacade
    {
        void CancelTicket(LogInToken<Customer> token, Ticket ticket);
        IList<Flight> GetAllMyFlights(LogInToken<Customer> token);
        Ticket PurchaseTicket(LogInToken<Customer> token, Flight flight);

    }
}
