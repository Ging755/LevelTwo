using LevelTwo.Service.Common;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTwo.Service
{
    public class DImodule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICategoryService>().To<CategoryService>();
            Bind<IItemService>().To<ItemService>();
            Bind<IOrderService>().To<OrderService>();
        }
    }
}
