using System;
using System.Collections.Generic;

namespace CatholicBuddies.Models
{
    public partial class Posts
    {
        public int Postid { get; set; }
        public int SenderId { get; set; }
        public int? RecipientId { get; set; }
        public string Message { get; set; }
        public DateTime? PostDate { get; set; }
        public byte[] PostImage { get; set; }
        public bool? MakePublic { get; set; }
        public bool? FlaggedOffensive { get; set; }

        public Users Recipient { get; set; }
        public Users Sender { get; set; }
    }
}
