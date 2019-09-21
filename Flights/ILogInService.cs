using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights
{
    public interface ILogInService
    {
        bool TryAdminLogin(string UserName, string Password, out LogInToken<Adminstrator> token);
        bool TryCustomerLogin(string UserName, string Password, out LogInToken<Customer> token);
        bool TryAirlineCompany(string UserName, string PAssword, out LogInToken<AirlineCompany> token);

    }
}
