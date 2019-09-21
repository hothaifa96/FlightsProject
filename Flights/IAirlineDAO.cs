using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights
{
    public interface IAirlineDAO : IBasicDB<AirlineCompany>
    {
        AirlineCompany GetAirlineByUserName(string username);
        IList<AirlineCompany> GetAllAirlinesByCountry(long countryid);
    }
}
