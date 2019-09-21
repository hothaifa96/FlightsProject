using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights
{
    public interface ILoggedInAirlinefacade
    {
        IList<Ticket> GetAllTickets(LogInToken<AirlineCompany> token);
        IList<Flight> GettAllFlighs(LogInToken<AirlineCompany> token);
        void CancelFlight(LogInToken<AirlineCompany> token, Flight flight);
        void CreateFlight(LogInToken<AirlineCompany> token, Flight flight);
        void UpdateFlight(LogInToken<AirlineCompany> token, Flight flight);
        void ChangeMyPassword(LogInToken<AirlineCompany> token, string oldPassword,string newPassword);
        void MofidyAirlineDetails(LogInToken<AirlineCompany> token, AirlineCompany airlineCompany);

        
    }
}
