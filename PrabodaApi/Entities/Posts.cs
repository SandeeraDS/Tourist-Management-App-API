using System;
using System.Collections.Generic;

namespace PrabodaApi.Entities
{
    public partial class Posts
    {
        public int PostId { get; set; }
        public int? FromId { get; set; }
        public int? ToId { get; set; }
        public string Post { get; set; }
        public string PostDate { get; set; }

        public virtual Tourist From { get; set; }
        public virtual Tourist PostNavigation { get; set; }
    }
}
