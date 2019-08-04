using LevelTwo.Model.Common;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTwo.Model
{
    public class DImodule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICategory>().To<Category>();
            Bind<IItem>().To<Item>();
        }
    }
}
