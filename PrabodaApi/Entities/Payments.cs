using System;
using System.Collections.Generic;

namespace PrabodaApi.Entities
{
    public partial class Payments
    {
        public Payments()
        {
            HotelRating = new HashSet<HotelRating>();
        }

        public int PaymentId { get; set; }
        public int? TouristId { get; set; }
        public int? TotalAmount { get; set; }
        public int? HotelId { get; set; }

        public virtual ICollection<HotelRating> HotelRating { get; set; }
        public virtual RoomBooking RoomBooking { get; set; }
        public virtual Tourist Tourist { get; set; }
    }
}
