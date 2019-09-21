using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Flights;
using System.Diagnostics;

namespace FlightsTestUnit
{
    /// <summary>
    /// Summary description for FacadesTeast
    /// </summary>
    [TestClass]
    public class AnonymouseFacadesTeast
    {
        [TestMethod]
        public void AnonymousrFacadeTest()
        {
            FlightDAOMSSQL flightsHandler = new FlightDAOMSSQL();
            flightsHandler.RemoveAll();
            #region filling the flights table
            CountryDAOMSSQL c = new CountryDAOMSSQL();
            c.RemoveAll();
            AirlineDAOMSSQL airline = new AirlineDAOMSSQL();
            airline.RemoveAll();
            Country c1 = new Country("israel");
            c.Add(c1);
            AirlineCompany airline1 = new AirlineCompany("eldal", "maher", "123", c1.Id);
            airline.Add(airline1);
            DateTime t = new DateTime(2019, 05, 05, 21, 22, 44);
            DateTime t1 = new DateTime(2019, 08, 29, 22, 33, 22);
            Debug.WriteLine(t1.ToString("MM/dd/yy H:mm:ss"));
            
            Flight f1 = new Flight(airline1.Id, c1.Id, c1.Id, t, t1, 22);
            flightsHandler.Add(f1);
            #endregion
            FlyingCenterSystem centerSystem = new FlyingCenterSystem();
            AnonymouseUserFacade anonymusefacade = centerSystem.OpenLogInSystem();
            Assert.IsNotNull(anonymusefacade);
            IList<AirlineCompany> listcomapny = anonymusefacade.GetAllAirlineCompanies();

            IList<Flight> flightsList = anonymusefacade.GetAllFlights();
            Assert.AreEqual(f1, flightsList[0]);
            Dictionary<Flight, int> valuePairs = anonymusefacade.GetAllFlightsVacancy();
            Assert.AreEqual(f1.RemainingTickets, valuePairs[f1]);
            Flight flightsById = anonymusefacade.GetFlightById(f1.Id);
            Assert.AreEqual(f1, flightsById);
            IList<Flight> FlightsByDtime = anonymusefacade.GetFlightsByDepartureDate(f1.DepartureTime);
            Assert.AreEqual(f1, FlightsByDtime[0]);
            IList<Flight> flighsByDesCountryList = anonymusefacade.GetFlightsByDestionationCountry(f1.DistinationCountryCode);
            Assert.AreEqual(f1, flighsByDesCountryList[0]);
            IList<Flight> FlightsByLandingTimeList = anonymusefacade.GetFlightsByLandingeDate(f1.LandingTime);
            Assert.AreEqual(f1, FlightsByLandingTimeList[0]);
            IList<Flight> FlightsByOriginCountry = anonymusefacade.GetFlightsByOriginCountry(f1.OriginCountryCode);
            Assert.AreEqual(f1, FlightsByOriginCountry[0]);

        }
        [TestMethod]
        public void AirlineComapnyFacadeTest()
        {
            string username = "elel";
            string password = "123";
           
            FlightDAOMSSQL flight = new FlightDAOMSSQL();
            CountryDAOMSSQL c = new CountryDAOMSSQL();
            AirlineDAOMSSQL airline = new AirlineDAOMSSQL();
            flight.RemoveAll();
            airline.RemoveAll();
            c.RemoveAll();
            Country c1 = new Country("israel");
            c.Add(c1);
            DateTime t = DateTime.Now;
            DateTime t1 = new DateTime(2019, 08, 29, 22, 33, 22);
            AirlineCompany company1 = new AirlineCompany("elal", "elel", "123", c1.Id);
            airline.Add(company1);
            Flight f1 = new Flight(company1.Id, c1.Id, c1.Id, t, t1, 22);
            flight.Add(f1);
            FlyingCenterSystem centerSystem = new FlyingCenterSystem();
            LoggedInAirlinefacade airlinefacade;
            bool filled = false;
            centerSystem.OpenLogInSystem(username, password, out airlinefacade , ref filled);
            if (filled)
            {
                IList<AirlineCompany> airlineCompaniesList = airlinefacade.GetAllAirlineCompanies();
                Assert.AreEqual(company1,airlineCompaniesList[0]);
                IList<Flight> flightsList=airlinefacade.GetAllFlights();
                Assert.AreEqual(f1, flightsList[0]);
                Dictionary<Flight,int> reaminingTicketMapFlights =airlinefacade.GetAllFlightsVacancy();
                Assert.AreEqual(f1.RemainingTickets, reaminingTicketMapFlights[f1]);
                IList<Ticket> ticketsOfAirlineCompanyList=airlinefacade.GetAllTickets(airlinefacade.AirlineToken);
                
                Flight flightById=airlinefacade.GetFlightById(f1.Id);
                Assert.AreEqual(f1, flightById);
                IList<Flight> fflightsByDeparyreTimeList=airlinefacade.GetFlightsByDepartureDate(f1.DepartureTime);
                Assert.AreEqual(f1, fflightsByDeparyreTimeList[0]);
                IList<Flight> flightsBydestinationCountryList = airlinefacade.GetFlightsByDestionationCountry(c1.Id);
                Assert.AreEqual(f1,flightsBydestinationCountryList[0]);
                IList<Flight> flightsByLandingTimeList=airlinefacade.GetFlightsByLandingeDate(f1.LandingTime);
                Assert.AreEqual(f1, flightsByLandingTimeList[0]);
                IList<Flight> flightsByOriginCountryList = airlinefacade.GetFlightsByOriginCountry(c1.Id);
                Assert.AreEqual(f1, flightsByOriginCountryList[0]);
                f1.RemainingTickets = f1.RemainingTickets - 3;
                airlinefacade.UpdateFlight(airlinefacade.AirlineToken, f1);
                Dictionary<Flight, int> updatedVanacyMapFligh = airlinefacade.GetAllFlightsVacancy();
                Assert.AreEqual(f1.RemainingTickets, updatedVanacyMapFligh[f1]);
                //Assert.AreSame(f1, airlinefacade.GetFlightById(f1.Id));
                ////airlinefacade.CancelFlight(airlinefacade.AirlineToken, f1);
                ////airlinefacade.ChangeMyPassword(airlinefacade.AirlineToken, "", "");
            }
            else
            {
                Assert.AreEqual(2, 3);
            }
        }
    }
}
