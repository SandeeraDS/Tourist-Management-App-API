using System;
using System.Collections.Generic;

namespace PrabodaApi.Entities
{
    public partial class TourGuideBooking
    {
        public int BookingId { get; set; }
        public int? TouristId { get; set; }
        public int? GuideId { get; set; }
        public DateTime? Date { get; set; }
        public int? NoOfDays { get; set; }
        public int? Status { get; set; }

        public virtual TourGuide Guide { get; set; }
        public virtual Tourist Tourist { get; set; }
    }
}
