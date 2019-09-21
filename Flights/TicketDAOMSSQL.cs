using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights
{
    public class TicketDAOMSSQL : ITicketDAO
    {
        static DBConnection con = new DBConnection ();
        public void Add(Ticket t)
        {
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = $"INSERT INTO Tickets (FLIGHT_ID,CUSTOMER_ID) VALUES ('{t.FlightId}','{t.CustomerId}');";
            cmd.ExecuteNonQuery();
            cmd.CommandText = $"SELECT ID FROM Tickets WHERE FLIGHT_ID = {t.FlightId}";
            while (cmd.ExecuteReader(CommandBehavior.Default).Read())
            {
                t.Id=(long)cmd.ExecuteReader(CommandBehavior.Default)[0];
                    
            }
            con.close(cmd);

        }

        public Ticket Get(long id)
        {
            Ticket ticket1 = new Ticket();
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = $"SELECT * FROM Tickets WHERE ID ={id};";
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
            while (reader.Read() == true)
            {
                ticket1.Id = id;
                ticket1.FlightId = (long) reader["FLIGHT_ID"];
                ticket1.CustomerId = (long)reader["CUSTOMER_ID"];

            }

            con.close(cmd);
            return ticket1;
        }

        public IList<Ticket> GetAll()
        {
            Ticket ticket1 = new Ticket();
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = $"SELECT * FROM Tickets;";
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
            List<Ticket> list = new List<Ticket>();
            while (reader.Read() == true)
            {
                ticket1.Id = (long)reader["ID"];
                ticket1.FlightId = (long)reader["FLIGHT_ID"];
                ticket1.CustomerId = (long)reader["CUSTOMER_ID"];
                list.Add(ticket1);
            }

            con.close(cmd);
            return list;
        }
        
        public void Remove(Ticket t)
        {
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = $"DELETE FROM Tickets WHERE ID={t.Id};";
            con.close(cmd);
        }
        public void RemoveAll()
        {
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = $"DELETE FROM Tickets ;";
            con.close(cmd);
        }

        public void Update(Ticket t)
        {
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = $"update Tickets set FLIGHT_ID = '{t.FlightId}' ,CUSTOMER_ID='{t.CustomerId}' WHERE ID = {t.Id}";
            con.close(cmd); 
        }
    }
}
