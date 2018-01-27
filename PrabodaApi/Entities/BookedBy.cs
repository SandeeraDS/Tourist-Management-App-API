using System;
using System.Collections.Generic;

namespace PrabodaApi.Entities
{
    public partial class BookedBy
    {
        public int TouristId { get; set; }
        public int BookingId { get; set; }

        public virtual CabBooking Booking { get; set; }
        public virtual RoomBooking BookingNavigation { get; set; }
        public virtual Tourist Tourist { get; set; }
    }
}
