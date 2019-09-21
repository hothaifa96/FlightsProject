using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights
{
    public class LoggedInCustomerFacade : AnonymouseUserFacade, ILoggedInCustomerFacade
    {
        public void CancelTicket(LogInToken<Customer> token, Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public IList<Flight> GetAllMyFlights(LogInToken<Customer> token)
        {
            return _FlightDAO.GetFlightsByCustomer(token.user);
        }

        public Ticket PurchaseTicket(LogInToken<Customer> token, Flight flight)
        {
            throw new NotImplementedException();
        }
    }
}
