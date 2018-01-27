using System;
using System.Collections.Generic;

namespace PrabodaApi.Entities
{
    public partial class CabRating
    {
        public int TouristId { get; set; }
        public int CabId { get; set; }
        public int? RatingValue { get; set; }

        public virtual CabDetails Tourist { get; set; }
        public virtual Tourist TouristNavigation { get; set; }
    }
}
