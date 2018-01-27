using System;
using System.Collections.Generic;

namespace PrabodaApi.Entities
{
    public partial class RoomBooking
    {
        public RoomBooking()
        {
            BookedBy = new HashSet<BookedBy>();
        }

        public int BookingId { get; set; }
        public int? PaymentId { get; set; }
        public DateTime? Date { get; set; }
        public int? NoOfRooms { get; set; }
        public int? TouristId { get; set; }
        public int? HotelId { get; set; }
        public int? RoomTypeId { get; set; }

        public virtual ICollection<BookedBy> BookedBy { get; set; }
        public virtual Payments Booking { get; set; }
        public virtual RoomType Hotel { get; set; }
    }
}
