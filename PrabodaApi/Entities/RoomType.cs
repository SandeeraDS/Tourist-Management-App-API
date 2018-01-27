using System;
using System.Collections.Generic;

namespace PrabodaApi.Entities
{
    public partial class RoomType
    {
        public RoomType()
        {
            RoomBooking = new HashSet<RoomBooking>();
            RoomDetails = new HashSet<RoomDetails>();
        }

        public int RoomTypeId { get; set; }
        public string RoomTypeName { get; set; }

        public virtual ICollection<RoomBooking> RoomBooking { get; set; }
        public virtual ICollection<RoomDetails> RoomDetails { get; set; }
    }
}
