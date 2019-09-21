using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights
{
    public class CustomerDAOMSSQL : ICustomerDAO
    {
        #region BASICDAO IMPLEMENTS
        static DBConnection con= new DBConnection();
        public void Add(Customer t)
        {
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = $"INSERT INTO Customers (FIRST_NAME , LAST_NAME,USER_NAME,PASSWORD,ADDRESS,PHONE_NUMBER,CREDIT_CARD_NUMBER) VALUES ('{t.FirstName}','{t.LastName}','{t.UserName}','{t.Password}','{t.Address}','{t.PhoneNumber}','{t.CreditCardNumber}');";
            cmd.ExecuteNonQuery();
           
           cmd.CommandText = $"SELECT ID FROM Customers WHERE FIRST_NAME='{t.FirstName}' ;";// defining the id of the customer by taking the id from the database list 
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
            while (reader.Read())
            {
                t.Id = (long)reader[0];
            } 
           
            con.close(cmd);
            
           
        }

        public Customer Get(long id)
        {
            Customer cust = new Customer();
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = $"SELECT * FROM Customers WHERE ID ={id};";
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
            while (reader.Read() == true)
            {
                cust.Id = (long)reader[0];
                cust.FirstName = (string)reader[1];
                cust.LastName = (string)reader[2];
                cust.UserName = (string)reader[3];
                cust.Password = (string)reader[4];
                cust.Address = (string)reader[5];
                cust.PhoneNumber = (string)reader[6];
                cust.CreditCardNumber = (string)reader[7];
                   
            }

            con.close(cmd);
            return cust;
        }

        public IList<Customer> GetAll()
        {
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = "SELECT * FROM Customers";
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
            Customer cust = new Customer();
            List<Customer> list = new List<Customer>();
            while (reader.Read()==true)
            {
                cust.Id = (long)reader[0];
                cust.FirstName = (string)reader[1];
                cust.LastName = (string)reader[2];
                cust.UserName = (string)reader[3];
                cust.Password = (string)reader[4];
                cust.Address = (string)reader[5];
                cust.PhoneNumber = (string)reader[6];
                cust.CreditCardNumber = (string)reader[7];
                list.Add(cust);
            }
            con.close(cmd);
            return list;
        }

       

        public void Remove(Customer t)
        {
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = $"DELETE FROM Customers WHERE ID={t.Id};";
            cmd.ExecuteNonQuery();
            con.close(cmd);
        }
        public void RemoveAll()
        {
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = " DELETE FROM Customers ;";
            cmd.ExecuteNonQuery();
            con.close(cmd);
        }

        public void Update(Customer t)
        {
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = $"UPDATE  Customers set FIRST_NAME = '{t.FirstName}' , LAST_NAME = '{t.LastName}' , USER_NAME = '{t.UserName}' , PASSWORD = '{t.Password}' , ADDRESS = '{t.Address}' , PHONE_NUMBER = '{t.PhoneNumber}', CREDIT_CARD_NUMBER ='{t.CreditCardNumber}' where ID = {t.Id} ;";
            cmd.ExecuteNonQuery();
            con.close(cmd);
        }
        #endregion
        #region ICUSTOMERDAO IMPLEMENTS
        public Customer GetCustomerByUserName(string username)
        {
            Customer cust = new Customer();
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = $"SELECT * FROM Customers WHERE USERNAME ='{username}';";
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
            while (reader.Read() == true)
            {
                cust.Id = (long)reader[0];
                cust.FirstName = (string)reader[1];
                cust.LastName = (string)reader[2];
                cust.UserName = (string)reader[3];
                cust.Password = (string)reader[4];
                cust.Address = (string)reader[5];
                cust.PhoneNumber = (string)reader[6];
                cust.CreditCardNumber = (string)reader[7];

            }

            con.close(cmd);
            return cust;
        }
        #endregion

    }
}
