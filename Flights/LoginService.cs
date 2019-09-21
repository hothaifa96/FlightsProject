using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights
{

    public class LoginService : ILogInService
    {
        static DBConnection con = new DBConnection();
        private AirlineDAOMSSQL _airlineDAO;
        private CustomerDAOMSSQL _customerDAO;
        private AdminstratorDAOMSSQL _adminsttratorDAO;
        public bool TryAdminLogin(string UserName, string Password, out LogInToken<Adminstrator> token)
        {
            Adminstrator admin = new Adminstrator();
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = $"select * FROM Administrator where USERNAME= '{UserName}' AND PASSWORD='{Password}';";
            SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.Default);

            while (reader.Read())
            {
                var r = new
                {
                    Id = (long)reader[0],
                    u = (string)reader[1],
                    p = (string)reader[2]
                };
                if (r == null)
                {
                    token = null;
                    return false;
                }
                else
                {
                    admin.Id = r.Id;
                    admin.UserName = r.u;
                    admin.Password = r.p;
                }

            }
            token = new LogInToken<Adminstrator>();
            token.user = admin;
            return true;
        }

        public bool TryAirlineCompany(string userName, string password, out LogInToken<AirlineCompany> token)
        {
            
            AirlineCompany airlineCompany = new AirlineCompany();
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText =$"select * FROM AirLineCompanies where USER_NAME= '{userName}' AND PASSWORD='{password}';";
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
            while (reader.Read())
            {
                var r = new
                {
                    Id = (long)reader["ID"],
                    AirlineName = (string)reader["AIRLINE_NAME"],
                    Username = (string)reader["USER_NAME"],
                    Password = (string)reader["PASSWORD"],
                    CountryCode = (long)reader["COUNTRY_CODE"],
                };
                if (r == null)
                {
                    token = null;
                    return false;
                }
                
                    airlineCompany.Id = r.Id;
                    airlineCompany.AirlineName = r.AirlineName;
                    airlineCompany.Username = r.Username;
                    airlineCompany.Password = r.Password;
                    airlineCompany.CountryCode = r.CountryCode; 
            }
            token = new LogInToken<AirlineCompany>();
            token.user = airlineCompany;

            return true;
        }

        public bool TryCustomerLogin(string UserName, string Password, out LogInToken<Customer> token)
        {
            Customer customer = new Customer ();
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = $"select * FROM AiRLineCompanies where USER_NAME= '{UserName}' AND PASSWORD='{Password}';";
            SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.Default);
            if (reader.FieldCount==0)
            {
                token = null;
                return false;
            }
            while (reader.Read())
            {
                customer.Id = (long)reader[0];
                customer.FirstName = (string)reader[1];
                customer.LastName = (string)reader[2];
                customer.UserName = (string)reader[3];
                customer.Password = (string)reader[4];
                customer.Address = (string)reader[5];
                customer.PhoneNumber = (string)reader[6];
                customer.CreditCardNumber = (string)reader[7];

            }
            token = new LogInToken<Customer>();
            token.user = customer;
            return true;

            
        }
    }

}
