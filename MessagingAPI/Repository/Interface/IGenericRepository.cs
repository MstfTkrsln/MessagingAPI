using System.Linq;
using System.Threading.Tasks;

namespace MessagingAPI.Repository
{
    public interface IGenericRepository<T>
    {
        T GetById(int id);

        int Insert(T entity);
    }
}