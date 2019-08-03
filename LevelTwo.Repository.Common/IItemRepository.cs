using LevelTwo.Model.Common;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTwo.Repository.Common
{
    public interface IItemRepository
    {
        Task<IItem> GetAsync(int id);

        IPagedList<IItem> GetListAsync();

        Task AddAsync(IItem entity);

        Task DeleteAsync(IItem entity);

        Task EditAsync(IItem entity);
    }
}
