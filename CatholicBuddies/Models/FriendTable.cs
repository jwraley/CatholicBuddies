using System;
using System.Collections.Generic;

namespace CatholicBuddies.Models
{
    public partial class FriendTable
    {
        public int FriendshipId { get; set; }
        public int? MyId { get; set; }
        public int? FriendId { get; set; }
        public byte? Relationship { get; set; }
    }
}
