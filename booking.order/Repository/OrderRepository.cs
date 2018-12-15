using booking.order.Abstract;
using booking.order.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace booking.order.Repository
{
    public class OrderRepository : IRepository<Order>
    {
        public void Add(Order item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Order item)
        {
            throw new NotImplementedException();
        }

        public Order Get(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Order Update(Order item)
        {
            throw new NotImplementedException();
        }
    }
}
