using booking.order.Abstract;
using booking.order.DAL;
using booking.order.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace booking.order.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private ApplicationContext context;

        public OrderRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public void Add(Order item)
        {
            context.Orders.Add(item);
            context.SaveChanges();
        }

        public void Delete(String id)
        {
            var order = context.Orders.FirstOrDefault(x => x.Id == id);
            if (order != null)
            {
                context.Orders.Remove(order);
                context.SaveChanges();
            }
        }

            public Order Get(string id)
        {
            return context.Orders.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Order> GetAll()
        {
            try
            {
                return context.Orders.ToList();
            }
            catch (Exception ex) { return null; }
        }

        public Order Update(Order item)
        {
            var order = context.Orders.FirstOrDefault(x => x.Id == item.Id);
            if (order != null)
            {
                order.ClientId = item.ClientId;
                order.FlightId = item.FlightId;
                order.Status = item.Status;
                order.Summ = item.Summ;
                context.Orders.Update(order);
                context.SaveChanges();
            }
            return order;
        }
    }
}
