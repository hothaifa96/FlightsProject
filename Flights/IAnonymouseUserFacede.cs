using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights
{
    public interface IAnonymouseUserFacede
    {
        IList<Flight> GetAllFlights();
        IList<AirlineCompany> GetAllAirlineCompanies();
        Dictionary<Flight, int> GetAllFlightsVacancy();
        Flight GetFlightById(long id);
        IList<Flight> GetFlightsByOriginCountry(long countryCode);
        IList<Flight> GetFlightsByDestionationCountry(long countryCode);
        IList<Flight> GetFlightsByDepartureDate(DateTime departureDate);
        IList<Flight> GetFlightsByLandingeDate(DateTime LandingDate);
    }
}
