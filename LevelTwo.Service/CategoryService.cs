using LevelTwo.Model.Common;
using LevelTwo.Repository.Common;
using LevelTwo.Service.Common;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTwo.Service
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository repo;

        public CategoryService(ICategoryRepository repo)
        {
            this.repo = repo;
        }

        public async Task AddAsync(ICategory entity)
        {
            await repo.AddAsync(entity);
        }

        public async Task DeleteAsync(ICategory entity)
        {
            await repo.DeleteAsync(entity);
        }

        public async Task EditAsync(ICategory entity)
        {
            await repo.EditAsync(entity);
        }

        public async Task<ICategory> GetAsync(int id)
        {
            return await repo.GetAsync(id);
        }

        public async Task<IEnumerable<ICategory>> GetListAsync()
        {
            return await repo.GetListAsync();
        }

        public async Task<IPagedList<ICategory>> GetListAsync(int? page, string search)
        {
            return await repo.GetListAsync(page, search);
        }
    }
}
