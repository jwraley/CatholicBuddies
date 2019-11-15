using System;
using System.Collections.Generic;

namespace CatholicBuddies.Models
{
    public partial class UserInfo
    {
        public UserInfo()
        {
            BuddyTableBuddy = new HashSet<BuddyTable>();
            BuddyTableMy = new HashSet<BuddyTable>();
            DirectMessageReceiver = new HashSet<DirectMessage>();
            DirectMessageSender = new HashSet<DirectMessage>();
            Photos = new HashSet<Photos>();
            PostsRecipient = new HashSet<Posts>();
            PostsSender = new HashSet<Posts>();
        }

        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public UserInfo User { get; set; }
        public UserInfo InverseUser { get; set; }
        public UserProfile UserProfile { get; set; }
        public ICollection<BuddyTable> BuddyTableBuddy { get; set; }
        public ICollection<BuddyTable> BuddyTableMy { get; set; }
        public ICollection<DirectMessage> DirectMessageReceiver { get; set; }
        public ICollection<DirectMessage> DirectMessageSender { get; set; }
        public ICollection<Photos> Photos { get; set; }
        public ICollection<Posts> PostsRecipient { get; set; }
        public ICollection<Posts> PostsSender { get; set; }
    }
}
