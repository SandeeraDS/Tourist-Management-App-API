using System;
using System.Collections.Generic;

namespace PrabodaApi.Entities
{
    public partial class ChatGrouping
    {
        public int ChatMemberId { get; set; }
        public int ChatGroupId { get; set; }

        public virtual ChatGroup ChatGroup { get; set; }
        public virtual ChatMember ChatMember { get; set; }
    }
}
