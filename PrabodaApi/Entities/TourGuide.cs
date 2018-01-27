using System;
using System.Collections.Generic;

namespace PrabodaApi.Entities
{
    public partial class TourGuide
    {
        public TourGuide()
        {
            ChatWhoToWhomReceiver = new HashSet<ChatWhoToWhom>();
            ChatWhoToWhomSender = new HashSet<ChatWhoToWhom>();
            TourGuideBooking = new HashSet<TourGuideBooking>();
            TourGuideRating = new HashSet<TourGuideRating>();
        }

        public int GuideId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public int? Rank { get; set; }
        public int? ChargePerDay { get; set; }
        public string Email { get; set; }
        public string Discription { get; set; }
        public byte[] Picture { get; set; }
        public int? Preference { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<ChatWhoToWhom> ChatWhoToWhomReceiver { get; set; }
        public virtual ICollection<ChatWhoToWhom> ChatWhoToWhomSender { get; set; }
        public virtual ICollection<TourGuideBooking> TourGuideBooking { get; set; }
        public virtual TourGuideComment TourGuideComment { get; set; }
        public virtual ICollection<TourGuideRating> TourGuideRating { get; set; }
        public virtual TourGuide Guide { get; set; }
        public virtual TourGuide InverseGuide { get; set; }
    }
}
