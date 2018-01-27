using System;
using System.Collections.Generic;

namespace PrabodaApi.Entities
{
    public partial class TourGuideComment
    {
        public int CommentId { get; set; }
        public string UserName { get; set; }
        public string GuideComment { get; set; }
        public int? GuideId { get; set; }

        public virtual TourGuide Comment { get; set; }
    }
}
