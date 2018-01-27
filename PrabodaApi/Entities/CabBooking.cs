using System;
using System.Collections.Generic;

namespace PrabodaApi.Entities
{
    public partial class CabBooking
    {
        public CabBooking()
        {
            BookedBy = new HashSet<BookedBy>();
        }

        public int BookingId { get; set; }
        public DateTime? Date { get; set; }
        public string BeginigLocation { get; set; }
        public int? TouristId { get; set; }
        public TimeSpan? Time { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<BookedBy> BookedBy { get; set; }
        public virtual Tourist Tourist { get; set; }
    }
}
