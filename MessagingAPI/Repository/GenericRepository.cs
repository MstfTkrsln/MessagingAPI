using System.Linq;
using System.Threading.Tasks;
using MessagingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MessagingAPI.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
        where T : class, new()
    {
        protected MessengerDbContext _dbContext { get; set; }

        public T GetById(int id)
        {
            return _dbContext.Find<T>(id);
        }

        public int Insert(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return _dbContext.SaveChanges();
        }

    }
}