using System;
using System.Collections.Generic;

namespace MessagingAPI.Models
{
    public partial class User
    {
        public User()
        {
            BlackListBlockedUser = new HashSet<BlackList>();
            BlackListUser = new HashSet<BlackList>();
            Log = new HashSet<Log>();
            MessageFromUser = new HashSet<Message>();
            MessageToUser = new HashSet<Message>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public ICollection<BlackList> BlackListBlockedUser { get; set; }
        public ICollection<BlackList> BlackListUser { get; set; }
        public ICollection<Log> Log { get; set; }
        public ICollection<Message> MessageFromUser { get; set; }
        public ICollection<Message> MessageToUser { get; set; }
    }
}
