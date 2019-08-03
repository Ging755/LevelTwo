using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTwo.Repository.Common
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int id);

        IDbSet<T> GetListAsync();

        Task AddAsync(T entity);

        Task DeleteAsync(T entity);

        Task EditAsync(T entity);
    }
}
