using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace booking.flight.Model
{
    public class Aircraft
    {
        [Key]
        public string Id { get; set; }
        private string Name { get; set; }
        private string NumberOfSeats { get; set; }
    }
}
