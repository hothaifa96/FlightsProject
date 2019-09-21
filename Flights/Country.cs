using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights
{
    public class Country : IPOCO
    {
        #region PROPS
        public long Id { get; set; }
        public string CountryName { get; set; }
        #endregion
        #region CTOR's
        public Country()
        {

        }

        public Country(string countryName)
        {
            
            CountryName = countryName;
        }

        #endregion
        #region OVERRIDES
        public override string ToString()
        {
            return $"country => Id= {this.Id} country name = {this.CountryName} ";
        }

        public static bool operator ==(Country c1, Country c2)
        {
            return c1.Id == c2.Id;
        }

        public static bool operator !=(Country c1, Country c2)
        {
            return !(c1 == c2);
        }

        public override bool Equals(object obj)
        {
            Country country1 = obj as Country;
            if (ReferenceEquals(country1, null))
            {
                return false;
            }
            return this == country1;
        }

        public override int GetHashCode()
        {
            return (int)this.Id;
        }
        #endregion
    }
}