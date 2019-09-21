using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights
{
    public class LoggedInAirlinefacade : AnonymouseUserFacade, ILoggedInAirlinefacade
    {
        static DBConnection con = new DBConnection();
        public LogInToken<AirlineCompany> AirlineToken { get; set; }
        public void CancelFlight(LogInToken<AirlineCompany> token, Flight flight)
        {
            if (flight.AirlineCompanyId == token.user.Id)
            {
                 base._FlightDAO.Remove(flight);
            }
           
        }

        public void ChangeMyPassword(LogInToken<AirlineCompany> token, string oldPassword, string newPassword)
        {
            
            if (token.user.Password == oldPassword)
            {
                SqlCommand cmd = con.GetSQLCommand();
                cmd.CommandText = $"UPDATE AieLineCompanies SET PASSWORD='{newPassword}' WHERE ID={token.user.Id}";
            }
        }

        public void CreateFlight(LogInToken<AirlineCompany> token, Flight flight)
        {
            if (token.user.Id == flight.AirlineCompanyId)
                base._FlightDAO.Add(flight);
            
        }

        public IList<Ticket> GetAllTickets(LogInToken<AirlineCompany> token)
        {
            List<Ticket> listOfTicketsFromTheSameCompany = new List<Ticket>();
            Ticket ticket = new Ticket();
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = $"SELEcT * FROM Tickets WHERE FLIGHT_ID=(SELECT ID FROM Flights WHERE AIRLINECOMPANY_ID ={token.user.Id} ); ";
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
            while (reader.Read())
            {
                ticket.Id = (long)reader["ID"];
                ticket.CustomerId=(long)reader["CUSTOMER_ID"];
                ticket.FlightId = (long)reader["FLIGHT_ID"];
                listOfTicketsFromTheSameCompany.Add(ticket);

            }
            return listOfTicketsFromTheSameCompany;
        }

        public IList<Flight> GettAllFlighs(LogInToken<AirlineCompany> token)
        {
            List<Flight> listOfFlighttsFromTheSameAirLineComapy = new List<Flight>();
            Flight flight= new Flight();
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = $"SELECT * FROM Flights WHERE AIRLINECOMPANY_ID={token.user.Id} ); ";
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
            while (reader.Read())
            {
                flight.Id = (long)reader[0];
                flight.AirlineCompanyId = (long)reader[1];
                flight.OriginCountryCode = (long)reader[2];
                flight.DistinationCountryCode = (long)reader[3];
                flight.DepartureTime = (DateTime)reader[4];
                flight.LandingTime = (DateTime)reader[4];
                flight.RemainingTickets = (int)reader[4];
                listOfFlighttsFromTheSameAirLineComapy.Add(flight);

            }
            return listOfFlighttsFromTheSameAirLineComapy;
        }

        public void MofidyAirlineDetails(LogInToken<AirlineCompany> token, AirlineCompany airlineCompany)
        {
            if (true)
            {
                base._airlineDAO.Update(airlineCompany);
            }

        }

        public void UpdateFlight(LogInToken<AirlineCompany> token, Flight flight)
        {
            if(token.user.Id== flight.AirlineCompanyId)
            {
                base._FlightDAO.Update(flight);
            }
        }
    }
}
