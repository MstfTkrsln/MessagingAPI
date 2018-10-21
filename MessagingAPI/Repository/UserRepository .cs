using MessagingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingAPI.Repository
{
    public class UserRepository : GenericRepository<User>,IUserRepository
    {
        public UserRepository(MessengerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetUserByName(string username)
        {
            return _dbContext.User.FirstOrDefault(u => u.UserName == username);
        }
    }
}
