using System;
using System.Collections.Generic;

namespace CatholicBuddies.Models
{
    public partial class UserProfile
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Diocese { get; set; }
        public byte[] ProfilePic { get; set; }

        public UserInfo User { get; set; }
        public UserProfile UserNavigation { get; set; }
        public UserProfile InverseUserNavigation { get; set; }
    }
}
