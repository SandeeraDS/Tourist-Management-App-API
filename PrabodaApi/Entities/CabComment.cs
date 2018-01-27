using System;
using System.Collections.Generic;

namespace PrabodaApi.Entities
{
    public partial class CabComment
    {
        public int CommentId { get; set; }
        public string CabComment1 { get; set; }
        public string UserName { get; set; }
        public int? CabId { get; set; }

        public virtual CabDetails Cab { get; set; }
    }
}
