using System;
using System.Collections.Generic;

namespace PrabodaApi.Entities
{
    public partial class RoomDetails
    {
        public int HotelId { get; set; }
        public int TypeId { get; set; }
        public int? RoomCharge { get; set; }
        public int? Availability { get; set; }
        public int? Persons { get; set; }

        public virtual Hotel Hotel { get; set; }
        public virtual RoomType Type { get; set; }
    }
}
