using System;
using System.Collections.Generic;

namespace PrabodaApi.Entities
{
    public partial class Friends
    {
        public int FriendshipId { get; set; }
        public int? MyId { get; set; }
        public int? FriendId { get; set; }
        public int? Status { get; set; }
        public int? PingStatus { get; set; }

        public virtual Tourist Friend { get; set; }
        public virtual Tourist My { get; set; }
    }
}
