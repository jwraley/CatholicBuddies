using System;
using System.Collections.Generic;

namespace CatholicBuddies.Models
{
    public partial class Posts
    {
        public int PostId { get; set; }
        public int SenderId { get; set; }
        public int? RecipientId { get; set; }
        public string Message { get; set; }
        public DateTime PostIndex { get; set; }
        public byte[] PostImage { get; set; }
        public bool? MakePublic { get; set; }
        public bool? FlaggedOffensive { get; set; }

        public UserInfo Recipient { get; set; }
        public UserInfo Sender { get; set; }
    }
}
