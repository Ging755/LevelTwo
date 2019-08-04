using LevelTwo.DAL;
using LevelTwo.Repository.Common;
using LevelTwo.Repository.UOFW;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTwo.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ShopContext context;
        protected IUnitOfWorkFactory uowFactory;

        public GenericRepository(ShopContext context, IUnitOfWorkFactory uowFactory)
        {
            this.context = context;
            this.uowFactory = uowFactory;
        }
        public virtual async Task AddAsync(T entity)
        {
            var unitofwork = uowFactory.CreateUnitOfWork();
            await unitofwork.AddAsync(entity);
            await unitofwork.CommitAsync();
        }

        public virtual async Task DeleteAsync(T entity)
        {
            var unitofwork = uowFactory.CreateUnitOfWork();
            await unitofwork.DeleteAsync(entity);
            await unitofwork.CommitAsync();
        }

        public virtual async Task EditAsync(T entity)
        {
            var unitofwork = uowFactory.CreateUnitOfWork();
            await unitofwork.UpdateAsync(entity);
            await unitofwork.CommitAsync();
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public virtual IDbSet<T> GetListAsync()
        {
            return context.Set<T>();
        }
    }
}
