using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights
{
    public class FlightDAOMSSQL : IFlightDAO
    {
        static DBConnection con= new DBConnection();
        public void Add(Flight t)
        {
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = $"INSERT INTO Flights (AIRLINECOMPANY_ID, ORIGIN_COUNTRY_CODE, DESTINATION_COUNTRY_CODE,DEPARTURE_TIME ,LANDING_TIME ,REMAINING_TICKETS) VALUES('{t.AirlineCompanyId}', '{t.OriginCountryCode}', '{t.DistinationCountryCode}', '{t.DepartureTime.ToString("MM/dd/yy H:mm:ss")}', '{t.LandingTime.ToString("MM/dd/yy H:mm:ss")}', '{t.RemainingTickets}');";
            cmd.ExecuteNonQuery();
            cmd.CommandText = $"SELECT TOP 1 * FROM Flights ORDER BY ID DESC ";
            t.Id=(long)cmd.ExecuteScalar();
            //SqlDataReader reader = cmd.ExecuteReader();
            //while (reader.HasRows)
            //{
            //    t.Id = (long)reader[0];
            //}
            con.close(cmd);
            
        }
        public Flight Get(long id)
        {
            Flight f1 = new Flight();
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = $"SELECT * FROM Flights WHERE ID ={id};";
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
            while (reader.Read() == true)
            {
                f1.Id = (long)reader[0];
                f1.AirlineCompanyId = (long)reader[1];
                f1.OriginCountryCode = (long)reader[2];
                f1.DistinationCountryCode = (long)reader[3];
                f1.DepartureTime = (DateTime)reader[4];
                f1.LandingTime= (DateTime)reader[4];
                f1.RemainingTickets = (int)reader[4];
                
            }

            con.close(cmd);
            return f1;
        }
        public IList<Flight> GetAll()
        {
            Flight f1 = new Flight();
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = $"SELECT * FROM Flights ;";
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
            List<Flight> list = new List<Flight>();
            while (reader.Read() == true)
            {
                f1.Id = (long)reader[0];
                f1.AirlineCompanyId = (long)reader[1];
                f1.OriginCountryCode = (long)reader[2];
                f1.DistinationCountryCode = (long)reader[3];
                f1.DepartureTime = (DateTime)reader[4];
                f1.LandingTime = (DateTime)reader[5];
                f1.RemainingTickets = (int)reader[6];
                list.Add(f1);
            }

            con.close(cmd);
            return list;
        }
        public Dictionary<Flight, int >  GetAllFlightVacancy()
        {
            Flight f = new Flight();
            Dictionary<Flight, int> remainingTicketsMapFlight = new Dictionary<Flight, int>();
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = "SELECT * FROM fLIGHTS WHERE REMAINING_TICKETS > 0";
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
            while (reader.Read())
            {
                f.Id = (long)reader[0];
                f.AirlineCompanyId = (long)reader[1];
                f.OriginCountryCode = (long)reader[2];
                f.DistinationCountryCode = (long)reader[3];
                f.DepartureTime = (DateTime)reader[4];
                f.LandingTime = (DateTime)reader[5];
                f.RemainingTickets = (int)reader[6];
                remainingTicketsMapFlight.Add(f, f.RemainingTickets);
                
            }
            con.close(cmd);
            return remainingTicketsMapFlight;
        }
        public IList<Flight> GetFlighstByOriginCountry(long countrycode)
        {
            SqlCommand cmd = con.GetSQLCommand();
            List<Flight> flghtsWIthSameCountryCode = new List<Flight>();
            Flight f = new Flight();
            cmd.CommandText = $"SELECT * FROM  Flights where ORIGIN_COUNTRY_CODE='{countrycode}';";
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
            while (reader.Read())
            {
                f.Id = (long)reader[0];
                f.AirlineCompanyId = (long)reader[1];
                f.OriginCountryCode = (long)reader[2];
                f.DistinationCountryCode = (long)reader[3];
                f.DepartureTime = (DateTime)reader[4];
                f.LandingTime = (DateTime)reader[5];
                f.RemainingTickets = (int)reader[6];
                flghtsWIthSameCountryCode.Add(f);
            }
            con.close(cmd);
            return flghtsWIthSameCountryCode;
        }
        public Flight GetFlightById(long id)
        {

            Flight f1 = new Flight();
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = $"SELECT * FROM Flights WHERE ID ={id};";
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
            while (reader.Read() == true)
            {
                f1.Id = (long)reader[0];
                f1.AirlineCompanyId = (long)reader[1];
                f1.OriginCountryCode = (long)reader[2];
                f1.DistinationCountryCode = (long)reader[3];
                f1.DepartureTime = (DateTime)reader[4];
                f1.LandingTime = (DateTime)reader[5];
                f1.RemainingTickets = (int)reader[6];

            }

            con.close(cmd);
            return f1;
        }
        public IList<Flight> GetFlightsByDepartureDate(DateTime departuredate)
        {
            Flight f = new Flight();
            List<Flight> flightsByDepatureDate = new List<Flight>();
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = $"SELECT * FROM Flights WHERE DEPARTURE_TIME between '{departuredate.ToString("MM/dd/yy")}' and '{departuredate.AddDays(1).ToString("MM/dd/yy")}';";
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
            while (reader.Read())
            {
                f.Id = (long)reader[0];
                f.AirlineCompanyId = (long)reader[1];
                f.OriginCountryCode = (long)reader[2];
                f.DistinationCountryCode = (long)reader[3];
                f.DepartureTime = (DateTime)reader[4];
                f.LandingTime = (DateTime)reader[5];
                f.RemainingTickets = (int)reader[6];
                flightsByDepatureDate.Add(f);
            }
            con.close(cmd);
            return flightsByDepatureDate;
        }
        public IList<Flight> GetFlightsByDestinationCountry(long countrycode)
        {
            Flight f = new Flight();
            List<Flight> flightsByDestinationDate = new List<Flight>();
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = $"SELECT * FROM Flights WHERE DESTINATION_COUNTRY_CODE = {countrycode};";
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
            while (reader.Read())
            {
                f.Id = (long)reader[0];
                f.AirlineCompanyId = (long)reader[1];
                f.OriginCountryCode = (long)reader[2];
                f.DistinationCountryCode = (long)reader[3];
                f.DepartureTime = (DateTime)reader[4];
                f.LandingTime = (DateTime)reader[5];
                f.RemainingTickets = (int)reader[6];
                flightsByDestinationDate.Add(f);
            }
            con.close(cmd);
            return flightsByDestinationDate;
        }
        public IList<Flight> GetFlightsByCustomer(Customer customer)
        {
            SqlCommand cmd = con.GetSQLCommand();
            Flight f = new Flight();
            List<Flight> flightsVyCustomerList = new List<Flight>();
            cmd.CommandText = $"SELECT * FROM Flights WHERE ID =(SELECT FLIGHT_ID FROM Tickets WHERE CUSTOMER_ID={customer.Id});";
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
            while (reader.Read())
            {
                f.Id = (long)reader[0];
                f.AirlineCompanyId = (long)reader[1];
                f.OriginCountryCode = (long)reader[2];
                f.DistinationCountryCode = (long)reader[3];
                f.DepartureTime = (DateTime)reader[4];
                f.LandingTime = (DateTime)reader[4];
                f.RemainingTickets = (int)reader[4];
                flightsVyCustomerList.Add(f);
            }
            con.close(cmd);
            return flightsVyCustomerList;
        }
        public IList<Flight> GetFlightsByLandingDate(DateTime landingdate)
        {

            Flight f = new Flight();
            List<Flight> flightsByLandingDate = new List<Flight>();
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = $"SELECT * FROM Flights WHERE LANDING_TIME between '{landingdate.ToString("MM/dd/yy")}' and '{landingdate.AddDays(1).ToString("MM/dd/yy")}';";
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
            while (reader.Read())
            {
                f.Id = (long)reader[0];
                f.AirlineCompanyId = (long)reader[1];
                f.OriginCountryCode = (long)reader[2];
                f.DistinationCountryCode = (long)reader[3];
                f.DepartureTime = (DateTime)reader[4];
                f.LandingTime = (DateTime)reader[5];
                f.RemainingTickets = (int)reader[6];
                flightsByLandingDate.Add(f);
            }
            con.close(cmd);
            return flightsByLandingDate;


           
        }
        public void Remove(Flight t)
        {
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = $"DELETE FROM Flights WHERE ID={t.Id};";
            cmd.ExecuteNonQuery();
            con.close(cmd);
        }
        public void RemoveAll()
        {
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = "DELETE FROM Flights ";
            cmd.ExecuteNonQuery();
            con.close(cmd);
        }
        public void Update(Flight t)
        {
            SqlCommand cmd = con.GetSQLCommand();// check the sql command in the next part of the code 
            cmd.CommandText = $"UPDATE Flights set AIRLINECOMPANY_ID = {t.AirlineCompanyId}, ORIGIN_COUNTRY_CODE = {t.OriginCountryCode}, DESTINATION_COUNTRY_CODE = {t.DistinationCountryCode}, DEPARTURE_TIME = '{t.DepartureTime.ToString("yyyy-MM-dd HH:mm:ss")}',LANDING_TIME='{t.LandingTime.ToString("yyyy-MM-dd HH:mm:ss")}',REMAINING_TICKETS={t.RemainingTickets} WHERE ID = {t.Id}";
            cmd.ExecuteNonQuery();
            con.close(cmd);
        }
    }
}
