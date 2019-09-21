using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights
{
    public class Ticket : IPOCO
    {
        #region PROPS
        public long Id { get; set; }
        public long FlightId { get; set; }
        public long CustomerId { get; set; }
        #endregion
        #region CTOR's
        public Ticket()
        {

        }

        public Ticket(long flightId, long customerId)
        {
            FlightId = flightId;
            CustomerId = customerId;
        }

        #endregion
        #region OVERRIDES
        public override string ToString()
        {
            return $"{this.Id}   {this.FlightId}   {this.CustomerId}";
        }

        public override bool Equals(object obj)
        {
            Ticket ticket = obj as Ticket;
            if (ReferenceEquals(ticket, null))
            {
                return false;
            }
            return this == ticket;
        }

        public override int GetHashCode()
        {
            return (int)this.Id;
        }
        public static bool operator ==(Ticket t1, Ticket t2)
        {
            return (t1.Id == t2.Id);
        }
        public static bool operator !=(Ticket t1, Ticket t2)
        {
            return !(t1 == t2);
        }
        #endregion
    }
}
