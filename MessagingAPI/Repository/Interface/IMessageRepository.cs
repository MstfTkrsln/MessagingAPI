using MessagingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingAPI.Repository
{
    public interface IMessageRepository : IGenericRepository<Message>
    {
        List<Message> GetMessagesByUserId(int userId);
    }
}
