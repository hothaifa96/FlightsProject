using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights
{
    public class AirlineCompany : IPOCO, IUSER
    {
        
        #region PROPS
        public long Id { get; set; }
        public string AirlineName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public long CountryCode { get; set; }
        #endregion
        #region CTORS 
        public AirlineCompany()
        {

        }

        public AirlineCompany(string airlineName, string username, string password, long countryCode)
        {
            AirlineName = airlineName;
            Username = username;
            Password = password;
            CountryCode = countryCode;
            
        }

        #endregion// the object get the ID after we insert the company to the database
        #region OVERRIDES
        public override string ToString()
        {
            return $"AirlineComapny => name: {this.Id}  name: {this.AirlineName} username :{this.Username}";
        }

        public override bool Equals(object obj)
        {
            AirlineCompany company = obj as AirlineCompany;
            if (ReferenceEquals(company, null))
            {
                return false;
            }
            return this == company;
        }

        public override int GetHashCode()
        {
            return (int)this.Id;
        }
        public static bool operator ==(AirlineCompany a1, AirlineCompany a2)
        {
            return (a1.Id == a2.Id);
        }
        public static bool operator !=(AirlineCompany a1, AirlineCompany a2)
        {
            return !(a1.Id == a2.Id);
        }

        #endregion

    }
}
