using MessagingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingAPI.Repository
{
    public class MessageRepository : GenericRepository<Message>,IMessageRepository
    {
        public MessageRepository(MessengerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Message> GetMessagesByUserId(int userId)
        {
            return _dbContext.Message.Where(m => m.FromUserId == userId || m.ToUserId == userId).OrderByDescending(m => m.CreatedTime).ToList();
        }

    }
}
