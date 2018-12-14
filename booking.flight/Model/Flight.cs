using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace booking.flight.Model
{
    public class Flight
    {
        [Key]
        public string Id { get; set; }
        private string Number { get; set; }
        public string AircraftId { get; set; }
        private string Date { get; set; }
        private string Time { get; set; }

    }
}
