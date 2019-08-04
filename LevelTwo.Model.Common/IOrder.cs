using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTwo.Model.Common
{
    public interface IOrder
    {
        int Id { get; set; }
        string RecipientName { get; set; }
        string RecipientSurname { get; set; }
        string RecipientAdress { get; set; }
        string RecipientZipCode { get; set; }
        string RecipientEmail { get; set; }
        string RecipientPhone { get; set; }
        string OrderReciveTime { get; set; }
        bool OrderSent { get; set; }
        ICollection<int> OrderedItems { get; set; }
    }
}
