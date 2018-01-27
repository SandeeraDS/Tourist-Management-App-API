using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrabodaApi.Model
{
    public class BookingDetails
    {
       public int BookingId { get; set; }
       public string HotelName { get; set; }
       public string RoomTypeName { get; set; }
       public int? PayamentAmount { get; set; }
       public DateTime? Date { get; set; }
       public int? NoOfRooms { get; set; }

        
        
    }
}
