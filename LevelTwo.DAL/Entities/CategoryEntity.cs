using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTwo.DAL.Entities
{
    public class CategoryEntity
    {
        public int Od { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        ICollection<ItemEntity> Items { get; set; }

        public CategoryEntity()
        {
            Items = new HashSet<ItemEntity>();
        }
    }
}
