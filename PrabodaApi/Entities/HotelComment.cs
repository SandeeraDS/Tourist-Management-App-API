using System;
using System.Collections.Generic;

namespace PrabodaApi.Entities
{
    public partial class HotelComment
    {
        public int CommentId { get; set; }
        public string HotelComment1 { get; set; }
        public string UserName { get; set; }
        public int? HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}
