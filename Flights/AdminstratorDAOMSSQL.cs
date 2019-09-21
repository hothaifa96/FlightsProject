using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights
{
    public class AdminstratorDAOMSSQL : IAdminstratorDAO
    {
        static DBConnection con = new DBConnection();
        #region IBASICDB IMPLEMENTS
        public void Add(Adminstrator t)
        {
            SqlCommand cmd = con.GetSQLCommand(); // con.GetSqlCommad returns SqlCommmand object
            cmd.CommandText = $"INSERT INTO Administrator (USERANME,PASSWORD) VALUES ('{t.UserName}','{t.Password}')";
            cmd.ExecuteNonQuery();
            con.close(cmd);
        }

        
        public Adminstrator Get(long id)
        {
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = $" SELECT * FROM Administrator WHERE ID ={id};";
            Adminstrator admin = new Adminstrator();
            SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.Default);
            while (reader.Read())
            {
                admin.Id= (long) reader["Id"];
                admin.UserName= (string) reader["USERNAME"];
                admin.Password= (string)reader["PASSWORD"];
            }
            con.close(cmd);
            return admin;
        }

        public IList<Adminstrator> GetAll()
        {
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = $" SELECT * FROM Administrator ;";
            Adminstrator admin = new Adminstrator();
            List<Adminstrator> list = new List<Adminstrator>();
            SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.Default);
            while (reader.Read())
            {
                admin.Id = (long)reader["Id"];
                admin.UserName = (string)reader["USERNAME"];
                admin.Password = (string)reader["PASSWORD"];
                list.Add(admin);
           }
            con.close(cmd);
            return list;
        }



        public void Remove(Adminstrator admin)
        {
            SqlCommand cmd = con.GetSQLCommand();
            cmd.CommandText = $" DELETE * FROM Administrator WHERE id ={admin.Id} ;";
            cmd.ExecuteNonQuery();
            con.close(cmd);

        }

        public void Update(Adminstrator t)
        {
            SqlCommand cmd = con.GetSQLCommand();           
            cmd.CommandText = $"UPDATE Administrator SET (PASSWORD='{t.Password}',USERNAME='{t.UserName}') where ID = {t.Id} ;";
            cmd.ExecuteNonQuery();
            con.close(cmd);
        }
#endregion
        #region INTERFACE IMPLEMENTs
        public void ChangePAssword(long id, string newpassword, string oldpasssword)
        {
            SqlCommand cmd = con.GetSQLCommand();
            Adminstrator admin = this.Get(id);//get admin by the id using function from this class
            if (admin.Password == oldpasssword)//check if the password and the string "oldpassword" matches
            {
                cmd.CommandText = $"UPDATE Administrator SET (PASSWORD='{newpassword}') where ID = {admin.Id} ;";
                cmd.ExecuteNonQuery();
            }
            con.close(cmd);
        }
        #endregion
    }

}
