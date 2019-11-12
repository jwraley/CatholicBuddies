using System;
using System.Collections.Generic;

namespace CatholicBuddies.Models
{
    public partial class Photos
    {
        public int PhotoId { get; set; }
        public int? UserId { get; set; }
        public byte[] UserPhoto { get; set; }
        public bool? MakePublic { get; set; }
        public DateTime? UploadTime { get; set; }
    }
}
