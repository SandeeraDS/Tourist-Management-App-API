using System;
using System.Collections.Generic;

namespace PrabodaApi.Entities
{
    public partial class ChatGroup
    {
        public ChatGroup()
        {
            ChatGrouping = new HashSet<ChatGrouping>();
        }

        public int ChatGroupId { get; set; }
        public DateTime? Date { get; set; }
        public string GroupName { get; set; }

        public virtual ICollection<ChatGrouping> ChatGrouping { get; set; }
    }
}
