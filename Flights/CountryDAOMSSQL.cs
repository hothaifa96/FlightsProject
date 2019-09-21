using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights
{
    public class CountryDAOMSSQL : ICountryDAO
    {
        #region BASICDAO IMPLEMENTS
        static DBConnection con = new DBConnection();
        public void Add(Country t)
        {
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = $"INSERT INTO Countries (COUNTRY_NAME) VALUES ('{t.CountryName}');";
            cmd.ExecuteNonQuery();
            cmd.CommandText = $"SELECT ID FROM Countries WHERE COUNTRY_NAME='{t.CountryName}' ;";// defining the id of the country by taking the id from the database list 
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
            while (reader.Read())
            {
                t.Id = (long)reader[0];
            }
            con.close(cmd);
        }
        public Country Get(long id)
        {
            Country country1 = new Country();
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = $"SELECT * FROM Countries WHERE ID ={id};";
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
            while (reader.Read() == true)
            {
                country1.Id = id;
                country1.CountryName = (string)reader["COUNTRY_NAME"];
                
            }

            con.close(cmd);
            return country1;
        }
        public IList<Country> GetAll()
        {
            Country country1 = new Country();
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = $"SELECT * FROM Countries ;";
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
            List<Country> list = new List<Country>();
            while (reader.Read() == true)
            {
                country1.Id = (long)reader["ID"];
                country1.CountryName = (string)reader["COUNTRY_NAME"];
                list.Add(country1);
            }

            con.close(cmd);
            return list;
        }
        public void Remove(Country t)
        {
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = $"DELETE FROM Countries WHERE ID={t.Id};";
            cmd.ExecuteNonQuery();
            con.close(cmd);
        }
        public void RemoveAll()
        {
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = $"DELETE FROM Countries;";
            cmd.ExecuteNonQuery();
            con.close(cmd);
        }
        public void Update(Country t)
        {
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = $"update Countries set COUNTRY_NAME = '{t.CountryName}' WHERE ID = {t.Id}";
            cmd.ExecuteNonQuery();
            con.close(cmd);
        }
        #endregion
    }
}
