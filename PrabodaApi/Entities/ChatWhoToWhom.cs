using System;
using System.Collections.Generic;

namespace PrabodaApi.Entities
{
    public partial class ChatWhoToWhom
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public int ChatId { get; set; }

        public virtual Chat Chat { get; set; }
        public virtual TourGuide Receiver { get; set; }
        public virtual Tourist ReceiverNavigation { get; set; }
        public virtual TourGuide Sender { get; set; }
        public virtual Tourist SenderNavigation { get; set; }
    }
}
