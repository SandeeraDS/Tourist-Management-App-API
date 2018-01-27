using System;
using System.Collections.Generic;

namespace PrabodaApi.Entities
{
    public partial class ChatMember
    {
        public ChatMember()
        {
            ChatGrouping = new HashSet<ChatGrouping>();
        }

        public int ChatMemberId { get; set; }
        public string ChantName { get; set; }

        public virtual ICollection<ChatGrouping> ChatGrouping { get; set; }
    }
}
