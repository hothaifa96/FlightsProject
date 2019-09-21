using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights
{
    public class LoggedInAdministratorFacade :AnonymouseUserFacade, ILoggedInAdministratorFacade
    {
        public void CreateNewAirline(LogInToken<Adminstrator> token, AirlineCompany airline)
        {
            if (airline != null)
            {
                _airlineDAO.Add(airline);
            }
        }

        public void CreateNewCustomer(LogInToken<Adminstrator> token, Customer customer)
        {
            if (customer!= null)
            {
                _customerDAO.Add(customer);
            }
        }

        public void RemoveAirline(LogInToken<Adminstrator> token, AirlineCompany airline)
        {
            if (airline != null)
                _airlineDAO.Remove(airline);
        }

        public void RemoveCustomer(LogInToken<Adminstrator> token, Customer customer)
        {
            if(customer != null)
                _customerDAO.Remove(customer);
        }

        public void UpdateAirlineDetails(LogInToken<Adminstrator> token, AirlineCompany airline)
        {
            if (airline != null )
                _airlineDAO.Update(airline);
        }

        public void UpdateCustoemrDetails(LogInToken<Adminstrator> token, Customer customer)
        {
            if (customer!= null)
            {
                _customerDAO.Update(customer);
            }
        }
    }
}
