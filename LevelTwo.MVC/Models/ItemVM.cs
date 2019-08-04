using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LevelTwo.MVC.Models
{
    public class ItemVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public decimal Price { get; set; }
        public bool Discount { get; set; }
        public int CategoryId { get; set; }
    }
}