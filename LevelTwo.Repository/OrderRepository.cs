using LevelTwo.DAL.Entities;
using LevelTwo.Model.Common;
using LevelTwo.Repository.Common;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTwo.Repository
{
    public class OrderRepository : IOrderRepository
    {
        IGenericRepository<OrderEntity> repo;

        public OrderRepository(IGenericRepository<OrderEntity> repo)
        {
            this.repo = repo;
        }
        public async Task AddAsync(IOrder entity)
        {
            await repo.AddAsync(AutoMapper.Mapper.Map<OrderEntity>(entity));
        }

        public async Task DeleteAsync(IOrder entity)
        {
            await repo.DeleteAsync(AutoMapper.Mapper.Map<OrderEntity>(entity));
        }

        public async Task EditAsync(IOrder entity)
        {
            await repo.EditAsync(AutoMapper.Mapper.Map<OrderEntity>(entity));
        }

        public async Task<IOrder> GetAsync(int id)
        {
            return AutoMapper.Mapper.Map<IOrder>(await repo.GetAsync(id));
        }

        public async Task<IEnumerable<IOrder>> GetListAsync()
        {
            return AutoMapper.Mapper.Map<IEnumerable<IOrder>>(await repo.GetListAsync().ToListAsync());
        }
    }
}
