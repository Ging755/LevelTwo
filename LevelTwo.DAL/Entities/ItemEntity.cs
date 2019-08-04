using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTwo.DAL.Entities
{
    public class ItemEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public decimal Price { get; set; }
        public bool Discount { get; set; }

        public int CategoryEntityId { get; set; }
        public CategoryEntity CategoryEntity { get; set; }
    }
}
