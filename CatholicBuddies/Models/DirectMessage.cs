using System;
using System.Collections.Generic;

namespace CatholicBuddies.Models
{
    public partial class DirectMessage
    {
        public int MessageId { get; set; }
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public string DirectMessage1 { get; set; }
    }
}
