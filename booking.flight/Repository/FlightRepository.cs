using booking.flight.Abstract;
using booking.flight.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace booking.flight.Repository
{
    public class FlightRepository : IRepository<Flight>
    {
        public void Add(Flight item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Flight item)
        {
            throw new NotImplementedException();
        }

        public Flight Get(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Flight> GetAll()
        {
            throw new NotImplementedException();
        }

        public Flight Update(Flight item)
        {
            throw new NotImplementedException();
        }
    }
}
