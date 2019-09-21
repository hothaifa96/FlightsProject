using System;
using System.Collections.Generic;
using Flights;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlightsTestUnit
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AirlineFuncsTest()
        {
            FlightDAOMSSQL flight = new FlightDAOMSSQL();
            flight.RemoveAll();
            CountryDAOMSSQL c = new CountryDAOMSSQL();
            c.RemoveAll();
            AirlineDAOMSSQL airline = new AirlineDAOMSSQL();
            airline.RemoveAll();
            AirlineCompany company1 = new AirlineCompany("elal", "elel", "123", 4);
            AirlineCompany company2 = new AirlineCompany("turkishairline", "ttt", "123", 3);
            AirlineDAOMSSQL aIrLine = new AirlineDAOMSSQL();
            aIrLine.RemoveAll();
            aIrLine.Add(company1);
            aIrLine.Add(company2);
            aIrLine.Remove(company1);
            AirlineCompany updatedAirlineCompany = aIrLine.Get(company2.Id);
            updatedAirlineCompany.Username = "hahah";
            aIrLine.Update(updatedAirlineCompany);
            IList<AirlineCompany> companies = aIrLine.GetAll();
            Assert.AreEqual(updatedAirlineCompany, aIrLine.GetAirlineByUserName(updatedAirlineCompany.Username));
            
        }
        [TestMethod]
        public void CustomersFuncsTest()
        {
            FlightDAOMSSQL flight = new FlightDAOMSSQL();
            flight.RemoveAll();
            CountryDAOMSSQL c = new CountryDAOMSSQL();
            c.RemoveAll();
            AirlineDAOMSSQL airline = new AirlineDAOMSSQL();
            airline.RemoveAll();
            Customer cust1 = new Customer("gal", "mazana", "userrr", "123", "afula", "0526614430","4580982574849111");
            Customer cust2 = new Customer("hamody", "zoubi", "hahaaaaa", "321", "ein harod", "0954542323521", "6528429299292");
            CustomerDAOMSSQL customer = new CustomerDAOMSSQL();
            customer.RemoveAll();
            customer.Add(cust1);
            customer.Add(cust2);
            customer.Remove(cust2);
            Customer upddatedCust = customer.Get(cust1.Id); upddatedCust.UserName = "hahahahaha";
            customer.Update(upddatedCust);
            IList<Customer> customers = customer.GetAll();
            Assert.AreEqual(customers[0], customer.Get(cust1.Id));
        }
        [TestMethod]
        public void CountryFuncsTest()
        {
            FlightDAOMSSQL flight = new FlightDAOMSSQL();
            flight.RemoveAll();
            CountryDAOMSSQL c = new CountryDAOMSSQL();
            c.RemoveAll();
            AirlineDAOMSSQL airline = new AirlineDAOMSSQL();
            airline.RemoveAll();
            Country c1, c2;
            c1 = new Country("UAE"); c2 = new Country("England");
            CountryDAOMSSQL country = new CountryDAOMSSQL();
            country.RemoveAll();
            country.Add(c1);
            country.Add(c2);
            country.Remove(c2);
            IList<Country> countries = country.GetAll();
            Country updatedCountry = country.Get(c1.Id); updatedCountry.CountryName = "Spain";
            country.Update((updatedCountry));
            Assert.AreEqual(updatedCountry, countries[0]);
            
        }
        [TestMethod]
        public void TicketFuncsTest()
        {
            FlightDAOMSSQL flight = new FlightDAOMSSQL();
            flight.RemoveAll();
            CountryDAOMSSQL c = new CountryDAOMSSQL();
            c.RemoveAll();
            AirlineDAOMSSQL airline = new AirlineDAOMSSQL();
            airline.RemoveAll();
            Ticket t1 = new Ticket(2, 3);
            Ticket t2 = new Ticket(4, 1);
            TicketDAOMSSQL ticket = new TicketDAOMSSQL();
            //ticket.RemoveAll();
            //ticket.Add(t1);
            //ticket.Add(t2);

        }
        [TestMethod]
        public void FlightFuncsTest()
        {
            FlightDAOMSSQL flight = new FlightDAOMSSQL();
            flight.RemoveAll();
            CountryDAOMSSQL c = new CountryDAOMSSQL();
            c.RemoveAll();
            AirlineDAOMSSQL airline = new AirlineDAOMSSQL();
            airline.RemoveAll();
            Country c1 = new Country("israel");
            
            c.Add(c1);
            AirlineCompany airline1 = new AirlineCompany("eldal", "maher", "123", c1.Id);
            
            airline.Add(airline1);
            DateTime t = DateTime.Now;
            DateTime t1 = new DateTime(2019, 8, 20, 22, 33, 22);
            Flight f1 = new Flight(airline1.Id, c1.Id, c1.Id, t, t1, 22);
            flight.Add(f1);
            Assert.AreEqual(f1, flight.GetFlighstByOriginCountry(f1.OriginCountryCode)[0]);


        }

    }
}
