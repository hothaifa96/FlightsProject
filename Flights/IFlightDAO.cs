using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights
{
    public interface IFlightDAO : IBasicDB<Flight>
    {
        Dictionary<Flight, int> GetAllFlightVacancy();
        Flight GetFlightById(long Id);
        IList<Flight> GetFlighstByOriginCountry(long countrycode);
        IList<Flight> GetFlightsByDestinationCountry(long countrycode);
        IList<Flight> GetFlightsByDepartureDate(DateTime departuredate);
        IList<Flight> GetFlightsByLandingDate(DateTime landingdate);
        IList<Flight> GetFlightsByCustomer(Customer customer);

    }
}
