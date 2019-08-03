using LevelTwo.Model.Common;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTwo.Repository.Common
{
    public interface ICategoryRepository
    {
        Task<ICategory> GetAsync(int id);

        IPagedList<ICategory> GetListAsync();

        Task AddAsync(ICategory entity);

        Task DeleteAsync(ICategory entity);

        Task EditAsync(ICategory entity);
    }
}
