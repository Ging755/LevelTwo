using LevelTwo.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTwo.DAL
{
    public class ShopContext : DbContext
    {
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ItemEntity> Items { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
    }
}
