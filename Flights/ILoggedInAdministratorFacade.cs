using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights
{
    public interface ILoggedInAdministratorFacade
    {
        void CreateNewAirline(LogInToken<Adminstrator> token, AirlineCompany airline);
        void UpdateAirlineDetails(LogInToken<Adminstrator> token, AirlineCompany airline);
        void RemoveAirline(LogInToken<Adminstrator> token, AirlineCompany airline);
        void CreateNewCustomer(LogInToken<Adminstrator> token, Customer customer);
        void UpdateCustoemrDetails(LogInToken<Adminstrator> token, Customer customer);
        void RemoveCustomer(LogInToken<Adminstrator> token, Customer customer);

    }
}
