using System.Collections.Generic;
using System.Threading.Tasks;

namespace Timipro.DataAccess.Interfaces
{
    public interface IGenericRepository<T>
    {

        Task<int> Create(T entity);
        Task<T> Get(object id);
        Task<List<T>> GetAll();

        Task<int> Delete(T entity);
        Task<int> Update(T entity);

    }
}
