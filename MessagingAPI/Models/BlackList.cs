using System;
using System.Collections.Generic;

namespace MessagingAPI.Models
{
    public partial class BlackList
    {
        public int BlackListId { get; set; }
        public int UserId { get; set; }
        public int BlockedUserId { get; set; }

        public User BlockedUser { get; set; }
        public User User { get; set; }
    }
}
