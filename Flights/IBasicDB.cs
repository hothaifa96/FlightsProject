using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights
{
    public interface IBasicDB<T> where T : IPOCO
    {
        T Get(long id);
        IList<T> GetAll();
        void Add(T t);
        void Remove(T t);
        void Update(T t);
    }
}