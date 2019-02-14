using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace booking.common.ViewModel
{
    
    public enum OrderStatus
    {
        booked = 0,
        paid = 1,
        completed = 2,
        closed = 3,
        canceled = 4
    }
}
