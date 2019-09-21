using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights
{
    public class DBConnection
    {
        
        public SqlCommand GetSQLCommand()
        {
            // this class handle my database connection here i define the path and close connections
             SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(@"Server = tcp:hothaifasdb.database.windows.net, 1433; Initial Catalog = FlightCenterDB; Persist Security Info = False; User ID = hothaifa; Password =Password1!; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            return cmd;
            
        }
        public void close(SqlCommand cmd)
        {
            cmd.Connection.Close();
        }
    }
}
