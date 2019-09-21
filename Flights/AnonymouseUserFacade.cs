using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights
{
    public class AnonymouseUserFacade : FacadeBase, IAnonymouseUserFacede
    {
        public IList<AirlineCompany> GetAllAirlineCompanies()
        {
            return base._airlineDAO.GetAll();
        }
        public IList<Flight> GetAllFlights()
        {
            return base._FlightDAO.GetAll();
        }
        public Dictionary<Flight, int> GetAllFlightsVacancy()
        {
            return base._FlightDAO.GetAllFlightVacancy();
        }
        public Flight GetFlightById(long id)
        {
            return base._FlightDAO.GetFlightById(id);
        }
        public IList<Flight> GetFlightsByDepartureDate(DateTime departureDate)
        {
            return base._FlightDAO.GetFlightsByDepartureDate(departureDate);
            
        }
        public IList<Flight> GetFlightsByDestionationCountry(long countryCode)
        {
            return base._FlightDAO.GetFlightsByDestinationCountry(countryCode);
        }
        public IList<Flight> GetFlightsByLandingeDate(DateTime LandingDate)
        {
            return base._FlightDAO.GetFlightsByLandingDate(LandingDate);
        }
        public IList<Flight> GetFlightsByOriginCountry(long  countryCode)
        {
            return base._FlightDAO.GetFlighstByOriginCountry(countryCode);
        }
    }
}
