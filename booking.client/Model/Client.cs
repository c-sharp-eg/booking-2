using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace booking.client.Model
{
    public class Client
    {
        [Key]
        public string Id { get; set; }
        private string Firstname { get; set; }
        private string Midlename { get; set; }
        private string Lastname { get; set; }
        private int Age { get; set; }


    }
}
