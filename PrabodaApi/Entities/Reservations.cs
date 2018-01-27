using System;
using System.Collections.Generic;

namespace PrabodaApi.Entities
{
    public partial class Reservations
    {
        public int ReservationId { get; set; }
        public int? RoomTypeId { get; set; }
        public int? HotelId { get; set; }
        public DateTime? Date { get; set; }
        public int? TouristId { get; set; }

        public virtual Hotel Hotel { get; set; }
        public virtual Tourist Tourist { get; set; }
    }
}
