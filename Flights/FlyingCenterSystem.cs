using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights
{
    public class FlyingCenterSystem
    {
        static public string FacadeUserName { get; private set; }
        static public string FacadePassword { get; private set; }
        private static FlyingCenterSystem _instance;
        private static object key;
        private IUSER user;
        
        
        public FlyingCenterSystem()
        {

        }
        static FlyingCenterSystem GetFlyingCenterSystem()
        {
            lock (key)
            {
                if (_instance == null)
                {
                    _instance = new FlyingCenterSystem();
                }
            }
            return _instance;
        }
         public AnonymouseUserFacade OpenLogInSystem()
        { 
            return new AnonymouseUserFacade();
        }
        public void OpenLogInSystem(string username,string password,out LoggedInAdministratorFacade administratorFacade)
        {
            FacadeUserName = username;
            FacadePassword = password;
            LoginService login = new LoginService();
            if (login.TryAdminLogin(FacadeUserName, FacadePassword, out LogInToken<Adminstrator> AdminstratorToken))
            {
                user = AdminstratorToken.user;
                administratorFacade=new LoggedInAdministratorFacade();
            }
            administratorFacade= null;
        }
        public void OpenLogInSystem(string username, string password,out LoggedInAirlinefacade airlineFacade, ref bool b)
        {
            FacadeUserName = username;
            FacadePassword = password;
            b = false;
            LoginService login = new LoginService();
            if (login.TryAirlineCompany(FacadeUserName, FacadePassword, out LogInToken<AirlineCompany> airlineToken))
            {
                user = airlineToken.user;
                airlineFacade= new LoggedInAirlinefacade();
                airlineFacade.AirlineToken = airlineToken;
                b = true;
            }
            else 
                airlineFacade= null;
        }
        public void OpenLogInSystem(string username, string password,out LoggedInCustomerFacade customerFacade)
        {
            FacadeUserName = username;
            FacadePassword = password;
            LoginService login = new LoginService();
            if (login.TryAdminLogin(FacadeUserName, FacadePassword, out LogInToken<Adminstrator> AdminstratorToken))
            {
                user = AdminstratorToken.user;
                customerFacade= new LoggedInCustomerFacade();
            }
            customerFacade=null;
        }
    }
}
