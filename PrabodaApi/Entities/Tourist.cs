using System;
using System.Collections.Generic;

namespace PrabodaApi.Entities
{
    public partial class Tourist
    {
        public Tourist()
        {
            BookedBy = new HashSet<BookedBy>();
            CabBooking = new HashSet<CabBooking>();
            CabRating = new HashSet<CabRating>();
            ChatWhoToWhomReceiverNavigation = new HashSet<ChatWhoToWhom>();
            ChatWhoToWhomSenderNavigation = new HashSet<ChatWhoToWhom>();
            FriendsFriend = new HashSet<Friends>();
            FriendsMy = new HashSet<Friends>();
            HotelRating = new HashSet<HotelRating>();
            Payments = new HashSet<Payments>();
            PostsFrom = new HashSet<Posts>();
            Reservations = new HashSet<Reservations>();
            TourGuideBooking = new HashSet<TourGuideBooking>();
            TourGuideRating = new HashSet<TourGuideRating>();
        }

        public int TouristId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string Email { get; set; }
        public string Discription { get; set; }
        public byte[] Picture { get; set; }

        public virtual ICollection<BookedBy> BookedBy { get; set; }
        public virtual ICollection<CabBooking> CabBooking { get; set; }
        public virtual ICollection<CabRating> CabRating { get; set; }
        public virtual ICollection<ChatWhoToWhom> ChatWhoToWhomReceiverNavigation { get; set; }
        public virtual ICollection<ChatWhoToWhom> ChatWhoToWhomSenderNavigation { get; set; }
        public virtual ICollection<Friends> FriendsFriend { get; set; }
        public virtual ICollection<Friends> FriendsMy { get; set; }
        public virtual ICollection<HotelRating> HotelRating { get; set; }
        public virtual ICollection<Payments> Payments { get; set; }
        public virtual ICollection<Posts> PostsFrom { get; set; }
        public virtual Posts PostsPostNavigation { get; set; }
        public virtual ICollection<Reservations> Reservations { get; set; }
        public virtual ICollection<TourGuideBooking> TourGuideBooking { get; set; }
        public virtual ICollection<TourGuideRating> TourGuideRating { get; set; }
    }
}
