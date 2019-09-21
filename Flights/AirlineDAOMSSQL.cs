using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights
{
    public class AirlineDAOMSSQL : IAirlineDAO
    {
        static DBConnection con = new DBConnection();// defining the conection calss 
        #region IBASICDB IMPLEMENTS
         public void Add(AirlineCompany t)
        {
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = $"INSERT INTO AirLineCompanies (AIRLINE_NAME,USER_NAME,PASSWORD,COUNTRY_CODE) VALUES ('{t.AirlineName}','{t.Username}','{t.Password}',{t.CountryCode});";
            cmd.ExecuteNonQuery();// inserting the company to the database 
            con.close(cmd);
            SqlCommand command = con.GetSQLCommand();
            command.CommandText = $"SELECT ID FROM AirLineCompanies WHERE AIRLINE_NAME='{t.AirlineName}' ;";// defining the id of the company by taking the id from the database list 
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.Default);
            while (reader.Read())
            {
                t.Id = (long)reader[0];
            }
            con.close(command);
        }

         public AirlineCompany Get(long id)
         {
            AirlineCompany air1 = new AirlineCompany();
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = $"SELECT * FROM AirLineCompanies WHERE ID ={id};";
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
            while (reader.Read() == true)
            {
                air1.Id = (long)reader[0];
                air1.AirlineName = (string)reader[1];
                air1.Username = (string)reader[2];
                air1.Password = (string)reader[3];
                air1.CountryCode = (long)reader[4];
            }

            con.close(cmd);
            return air1;
         }

       

         public IList<AirlineCompany> GetAll()
        {
            AirlineCompany air1 = new AirlineCompany();
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = $"SELECT * FROM AirLineCompanies ;";
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
            List<AirlineCompany> list = new List<AirlineCompany>();
            while (reader.Read() == true)
            {
                air1.Id = (long)reader[0];
                air1.AirlineName = (string)reader[1];
                air1.Username = (string)reader[2];
                air1.Password = (string)reader[3];
                air1.CountryCode = (long)reader[4];
                list.Add(air1);
            }

            con.close(cmd);
            return list;
        }

       

         public void Remove(AirlineCompany t)
        {
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = $"DELETE FROM AirLineCompanies WHERE ID={t.Id};";
            cmd.ExecuteNonQuery();
            con.close(cmd);
        }
        public void RemoveAll()
        {
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = $"DELETE FROM AirLineCompanies ;";
            cmd.ExecuteNonQuery();
            con.close(cmd);
        }

        public void Update(AirlineCompany t)
        {
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = $"update AirLineCompanies set AIRLINE_NAME = '{t.AirlineName}', USER_NAME = '{t.Username}', PASSWORD = '{t.Password}', COUNTRY_CODE = {t.CountryCode} WHERE ID = {t.Id}";
            cmd.ExecuteNonQuery();
            con.close(cmd);
        }
        #endregion
        #region IAIRLINEDAO IMPLEMENTS
         public IList<AirlineCompany> GetAllAirlinesByCountry(long countryid)
        {
            AirlineCompany air1 = new AirlineCompany();
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = $"SELECT * FROM AirLineCompanies WHERE COUNTRY_CODE={countryid};";
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
            List<AirlineCompany> list = new List<AirlineCompany>();
            while (reader.Read() == true)
            {
                air1.Id = (long)reader[0];
                air1.AirlineName = (string)reader[1];
                air1.Username = (string)reader[2];
                air1.Password = (string)reader[3];
                air1.CountryCode = (long)reader[4];
                list.Add(air1);
            }

            con.close(cmd);
            return list;
        }
         public AirlineCompany GetAirlineByUserName(string username)

        {
            AirlineCompany air1 = new AirlineCompany();
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = $"SELECT * FROM AirLineCompanies WHERE USER_NAME ='{username}';";
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
            while (reader.Read() == true)
            {
                air1.Id = (long)reader[0];
                air1.AirlineName = (string)reader[1];
                air1.Username = (string)reader[2];
                air1.Password = (string)reader[3];
                air1.CountryCode = (long)reader[4];
            }

            con.close(cmd);
            return air1;
        }
        #endregion
    }
}
