using LevelTwo.Model.Common;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTwo.Repository.Common
{
    public interface IOrderRepository
    {
        Task<IOrder> GetAsync(int id);

        Task<IPagedList<IOrder>> GetListAsync();

        Task AddAsync(IOrder entity);

        Task DeleteAsync(IOrder entity);

        Task EditAsync(IOrder entity);
    }
}
