using LevelTwo.DAL.Entities;
using LevelTwo.Repository.Common;
using LevelTwo.Repository.UOFW;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTwo.Repository
{
    public class DImodule : NinjectModule
    {
        public override void Load()
        {
            Bind<IGenericRepository<CategoryEntity>>().To<GenericRepository<CategoryEntity>>();
            Bind<IGenericRepository<ItemEntity>>().To<GenericRepository<ItemEntity>>();
            Bind<IGenericRepository<OrderEntity>>().To<GenericRepository<OrderEntity>>();
            Bind<ICategoryRepository>().To<CategoryRepository>();
            Bind<IItemRepository>().To<ItemRepository>();
            Bind<IOrderRepository>().To<OrderRepository>();
            Bind<IUnitOfWorkFactory>().ToFactory();
        }
    }
}
