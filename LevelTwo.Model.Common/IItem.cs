using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTwo.Model.Common
{
    public interface IItem
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string ImagePath { get; set; }
        decimal Price { get; set; }
        bool Discount { get; set; }

        int CategoryId { get; set; }
    }
}
