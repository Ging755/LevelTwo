using LevelTwo.Model.Common;
using LevelTwo.Repository.Common;
using LevelTwo.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTwo.Service
{
    public class OrderService : IOrderService
    {
        IOrderRepository repo;

        public OrderService(IOrderRepository repo)
        {
            this.repo = repo;
        }

        public async Task AddAsync(IOrder entity)
        {
            await repo.AddAsync(entity);
        }

        public async Task DeleteAsync(IOrder entity)
        {
            await repo.DeleteAsync(entity);
        }

        public async Task EditAsync(IOrder entity)
        {
            await repo.EditAsync(entity);
        }

        public async Task<IOrder> GetAsync(int id)
        {
            return await repo.GetAsync(id);
        }

        public async Task<IEnumerable<IOrder>> GetListAsync()
        {
            return await repo.GetListAsync();
        }
    }
}
