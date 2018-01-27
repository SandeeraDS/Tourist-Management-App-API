using System;
using System.Collections.Generic;

namespace PrabodaApi.Entities
{
    public partial class HotelRating
    {
        public int TouristId { get; set; }
        public int HotelId { get; set; }
        public int? RatingValue { get; set; }
        public int? PaymentId { get; set; }

        public virtual Hotel Hotel { get; set; }
        public virtual Payments Payment { get; set; }
        public virtual Tourist Tourist { get; set; }
    }
}
