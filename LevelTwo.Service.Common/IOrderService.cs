using LevelTwo.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTwo.Service.Common
{
    public interface IOrderService
    {
        Task<IOrder> GetAsync(int id);

        Task<IEnumerable<IOrder>> GetListAsync();

        Task AddAsync(IOrder entity);

        Task DeleteAsync(IOrder entity);

        Task EditAsync(IOrder entity);
    }
}
