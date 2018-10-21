using System;
using System.Collections.Generic;

namespace MessagingAPI.Models
{
    public partial class Log
    {
        public int LogId { get; set; }
        public int UserId { get; set; }
        public short LogType { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }

        public User User { get; set; }
    }
}
