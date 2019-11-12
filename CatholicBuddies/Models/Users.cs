using System;
using System.Collections.Generic;

namespace CatholicBuddies.Models
{
    public partial class Users
    {
        public Users()
        {
            PostsRecipient = new HashSet<Posts>();
            PostsSender = new HashSet<Posts>();
        }

        public int UserId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] ProfilePic { get; set; }
        public string UserCity { get; set; }
        public string UserState { get; set; }
        public string UserDiocese { get; set; }
        public DateTime? DateCreated { get; set; }

        public ICollection<Posts> PostsRecipient { get; set; }
        public ICollection<Posts> PostsSender { get; set; }
    }
}
