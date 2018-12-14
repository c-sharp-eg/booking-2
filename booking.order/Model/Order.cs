using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace booking.order.Model
{
    public class Order
    {
        [Key]
        public string Id { get; set; }
        private string FlightId { get; set; }
        private string ClientId { get; set; }
        private decimal Summ { get; set; }
        private OrderStatus Status { get; set; }
    }
}
