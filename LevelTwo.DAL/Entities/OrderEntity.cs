using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTwo.DAL.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public string RecipientName { get; set; }
        public string RecipientSurname { get; set; }
        public string RecipientAdress { get; set; }
        public string RecipientZipCode { get; set; }
        public string RecipientEmail { get; set; }
        public string RecipientPhone { get; set; }
        public string OrderReciveTime { get; set; }
        public bool OrderSent { get; set; }
        public ICollection<ItemEntity> OrderedItems { get; set; }

        public OrderEntity()
        {
            OrderedItems = new HashSet<ItemEntity>();
        }
    }
}
