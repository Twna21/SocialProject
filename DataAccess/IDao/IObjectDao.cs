using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IDao
{
    public interface IObjectDAO<T>
    {

        Task<List<T>> ShowAllAsync();
        Task CreateAsync(T obj);
        Task UpdateAsync(T obj);
        Task DeleteAsync(T obj);
        Task<T> GetByIdAsync(string id);
        Task DeleteAllAsync();

    }
}
