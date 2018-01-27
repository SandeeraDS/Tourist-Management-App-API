using System;
using System.Collections.Generic;

namespace PrabodaApi.Entities
{
    public partial class Hotel
    {
        public Hotel()
        {
            HotelComment = new HashSet<HotelComment>();
            HotelRating = new HashSet<HotelRating>();
            Reservations = new HashSet<Reservations>();
            RoomDetails = new HashSet<RoomDetails>();
        }

        public int HotelId { get; set; }
        public string UserName { get; set; }
        public int? Rank { get; set; }
        public string Email { get; set; }
        public double? Latitude { get; set; }
        public double? Longtitude { get; set; }
        public string Password { get; set; }
        public string Contact { get; set; }
        public string Discription { get; set; }

        public virtual ICollection<HotelComment> HotelComment { get; set; }
        public virtual ICollection<HotelRating> HotelRating { get; set; }
        public virtual ICollection<Reservations> Reservations { get; set; }
        public virtual ICollection<RoomDetails> RoomDetails { get; set; }
    }
}
