using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights
{
    public class Adminstrator: IUSER,IPOCO
    {
        #region DATA 
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        #endregion
        #region CTOR's
        public Adminstrator()
        {

        }

        public Adminstrator(long id, string userName, string password)
        {
            Id = id;
            UserName = userName;
            Password = password;
        }


        #endregion
        #region OVERRIDES
        public override string ToString()
        {
            return "Admin => ID:" +this.Id+ "USername" +this.UserName;
        }
        
        public override bool Equals(object obj)
        {   
            Adminstrator admin = obj as Adminstrator;
            if (ReferenceEquals(admin, null))   
            {
                return false;
            }// in the id we check if the obj fit in the dcasting as Adminstrator
            return this == admin;// comparing the Id's
        }

        public override int GetHashCode()
        {
            return (int)this.Id;
        }
        public static bool operator ==(Adminstrator a1, Adminstrator a2)
        {
            return (a1.Id == a2.Id);
        }
        public static bool operator !=(Adminstrator a1, Adminstrator a2)
        {
            return !(a1 == a2);
        }

        #endregion

    }
}
