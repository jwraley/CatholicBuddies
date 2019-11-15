using System;
using System.Collections.Generic;

namespace CatholicBuddies.Models
{
    public partial class BuddyTable
    {
        public int FriendId { get; set; }
        public int? MyId { get; set; }
        public int? BuddyId { get; set; }
        public byte? Relationship { get; set; }

        public UserInfo Buddy { get; set; }
        public UserInfo My { get; set; }
    }
}
