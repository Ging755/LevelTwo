using LevelTwo.Model.Common;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTwo.Service.Common
{
    public interface ICategoryService
    {
        Task<ICategory> GetAsync(int id);

        Task<IEnumerable<ICategory>> GetListAsync();

        Task<IPagedList<ICategory>> GetListAsync(int? page, string search);

        Task AddAsync(ICategory entity);

        Task DeleteAsync(ICategory entity);

        Task EditAsync(ICategory entity);
    }
}
