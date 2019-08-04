using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTwo.DAL.Entities
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        ICollection<ItemEntity> ItemEntities { get; set; }

        public CategoryEntity()
        {
            ItemEntities = new HashSet<ItemEntity>();
        }
    }
}
