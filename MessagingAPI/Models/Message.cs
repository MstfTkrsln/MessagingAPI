using System;
using System.Collections.Generic;

namespace MessagingAPI.Models
{
    public partial class Message
    {
        public int MessageId { get; set; }
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedTime { get; set; }

        public User FromUser { get; set; }
        public User ToUser { get; set; }
    }
}
