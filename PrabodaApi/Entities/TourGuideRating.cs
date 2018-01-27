using System;
using System.Collections.Generic;

namespace PrabodaApi.Entities
{
    public partial class TourGuideRating
    {
        public int TouristId { get; set; }
        public int TourGuideId { get; set; }
        public int? RatingValue { get; set; }

        public virtual TourGuide TourGuide { get; set; }
        public virtual Tourist Tourist { get; set; }
    }
}
