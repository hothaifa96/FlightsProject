using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights
{
    public class LogInToken<T> where T : IUSER 
    {
        public T user { get; set; }
    }
}
