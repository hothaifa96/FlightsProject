using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights
{
    public class Customer : IPOCO, IUSER
    {
        #region PROP's
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string CreditCardNumber { get; set; }
        #endregion
        #region CTOR's
        public Customer()
        {

        }

        public Customer(string firstName, string lastName, string userName, string password, string address, string phoneNumber, string creditCardNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = password;
            Address = address;
            PhoneNumber = phoneNumber;
            CreditCardNumber = creditCardNumber;
        }

        #endregion
        #region OVERRIDES
        public override string ToString()
        {
            return $"Customer => id:{this.Id}  first name : {this.FirstName} last name : {this.LastName} username : {this.UserName} Phone Number: {this.PhoneNumber}";
        }

        public override bool Equals(object obj)
        {
            Customer cust = obj as Customer;
            if (ReferenceEquals(cust, null))
                return false;
            return (this == cust);
        }

        public static bool operator ==(Customer c1, Customer c2)
        {
            return (c1.Id == c2.Id);
        }

        public static bool operator !=(Customer c1, Customer c2)
        {
            return !(c1.Id == c2.Id);

        }
        public override int GetHashCode()
        {
            return (int)this.Id;
        }
        #endregion
    }
}
