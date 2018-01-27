using System;
using System.Collections.Generic;

namespace PrabodaApi.Entities
{
    public partial class Chat
    {
        public Chat()
        {
            ChatWhoToWhom = new HashSet<ChatWhoToWhom>();
        }

        public int ChatId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ChatWhoToWhom> ChatWhoToWhom { get; set; }
    }
}
