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
    public class ItemRepository : IItemRepository
    {
        IGenericRepository<ItemEntity> repo;
        public ItemRepository(IGenericRepository<ItemEntity> repo)
        {
            this.repo = repo;
        }

        public async Task AddAsync(IItem entity)
        {
            await repo.AddAsync(AutoMapper.Mapper.Map<ItemEntity>(entity));
        }

        public async Task DeleteAsync(IItem entity)
        {
            await repo.DeleteAsync(AutoMapper.Mapper.Map<ItemEntity>(entity));
        }

        public async Task EditAsync(IItem entity)
        {
            await repo.EditAsync(AutoMapper.Mapper.Map<ItemEntity>(entity));
        }

        public async Task<IItem> GetAsync(int id)
        {
            return AutoMapper.Mapper.Map<IItem>(await repo.GetAsync(id));
        }

        public async Task<IPagedList<IItem>> GetListAsync(int? page, string search, string priceorder, string discount)
        {
            var items = AutoMapper.Mapper.Map<IQueryable<IItem>>(repo.GetListAsync().AsQueryable());
            IPagedList<IItem> model;
            if (!string.IsNullOrEmpty(search))
            {
                items = items.Where(x => x.Name.ToUpper().Contains(search.ToUpper())).AsQueryable();
            }
            if (!string.IsNullOrEmpty(discount))
            {
                if (discount == "true")
                {
                    items = items.Where(x => x.Discount == true).AsQueryable();
                }
                else
                {
                    items = items.Where(x => x.Discount == false).AsQueryable();
                }
            }
            if (!string.IsNullOrEmpty(priceorder))
            {
                switch (priceorder.ToUpper())
                {
                    case "ASCENDING":
                        items = items.OrderBy(x => x.Price).AsQueryable();
                        break;
                    case "DESCENDING":
                        items = items.OrderByDescending(x => x.Price).AsQueryable();
                        break;
                    default:
                        model = items.OrderByDescending(x => x.Id).ToPagedList((int)page, 3);
                        break;
                }
                model = items.ToPagedList((int)page, 6);
            }
            else
            {
                model = items.OrderByDescending(x => x.Id).ToPagedList((int)page, 3);
            }
            return (new StaticPagedList<IItem>(model, model.GetMetaData()));
        }
    }
}
