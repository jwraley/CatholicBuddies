using System;
using System.Collections.Generic;

namespace CatholicBuddies.Models
{
    public partial class DirectMessage
    {
        public int MessageId { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string MessageText { get; set; }

        public UserInfo Receiver { get; set; }
        public UserInfo Sender { get; set; }
    }
}
