using MessagingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingAPI.Repository
{
    public class BlackListRepository : GenericRepository<BlackList>, IBlackListRepository
    {
        public BlackListRepository(MessengerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<BlackList> GetBlackListByUserId(int userId)
        {
            return _dbContext.BlackList.Where(m => m.UserId == userId).ToList();
        }
    }
}
