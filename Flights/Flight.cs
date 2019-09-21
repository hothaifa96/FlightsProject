using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights
{
    public class Flight : IPOCO
    {
        #region PROPS
        public long Id { get; set; }
        public long AirlineCompanyId { get; set; }
        public long OriginCountryCode { get; set; }
        public long DistinationCountryCode { get; set; }
       // public long Departure { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime LandingTime { get; set; }
        public int RemainingTickets { get; set; }
        #endregion
        #region CTOR's
        public Flight()
        {

        }

        public Flight(long airlineCompanyId, long originCountryCode, long distinationCountryCode, /*long departure,*/ DateTime departureTime, DateTime landingTime, int remainingTickets)
        {
            AirlineCompanyId = airlineCompanyId;
            OriginCountryCode = originCountryCode;
            DistinationCountryCode = distinationCountryCode;
          //  Departure = departure;
            DepartureTime = departureTime;
            LandingTime = landingTime;
            RemainingTickets = remainingTickets;
        }

        #endregion
        #region OVERRIDES
        public override string ToString()
        {
            return $"flight => id: {this.Id} departure time :{this.DepartureTime} landing time:{this.LandingTime} remaining tickets:{this.RemainingTickets}";
        }

        public override bool Equals(object obj)
        {
            Flight flight = obj as Flight;
            if (ReferenceEquals(flight, null))
            {
                return false;
            }
            return this == flight;
        }

        public override int GetHashCode()
        {
            return (int)this.Id;
        }

        public static bool operator ==(Flight f1, Flight f2)
        {
            return (f1.Id == f2.Id);
        }
        public static bool operator !=(Flight f1, Flight f2)
        {
            return !(f1 == f2);
        }
        #endregion
    }
}