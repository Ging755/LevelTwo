using LevelTwo.DAL.Entities;
using LevelTwo.Model.Common;
using LevelTwo.Repository.Common;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTwo.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        IGenericRepository<CategoryEntity> repo;

        public CategoryRepository(IGenericRepository<CategoryEntity> repo)
        {
            this.repo = repo;
        }
        public async Task AddAsync(ICategory entity)
        {
           await repo.AddAsync(AutoMapper.Mapper.Map<CategoryEntity>(entity));
        }

        public async Task DeleteAsync(ICategory entity)
        {
            await repo.DeleteAsync(AutoMapper.Mapper.Map<CategoryEntity>(entity));
        }

        public async Task EditAsync(ICategory entity)
        {
            await repo.EditAsync(AutoMapper.Mapper.Map<CategoryEntity>(entity));
        }

        public async Task<ICategory> GetAsync(int id)
        {
            return AutoMapper.Mapper.Map<ICategory>(await repo.GetAsync(id));
        }

        public async Task<IPagedList<ICategory>> GetListAsync(int? page, string search)
        {
            var categories = repo.GetListAsync().AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                categories = categories.Where(x => x.Name.ToUpper() == search.ToUpper()).AsQueryable();
            }
            var categoriespaged = AutoMapper.Mapper.Map<IEnumerable<ICategory>>(categories).OrderBy(x => x.Id).ToPagedList((int)page, 3);
            return (categoriespaged);
        }
    }
}
