using LevelTwo.Model.Common;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LevelTwo.Service.Common
{
    public interface IItemService
    {
        Task<IItem> GetAsync(int id);

        Task<IPagedList<IItem>> GetListAsync(int? page, string search, string priceorder, string discount);

        Task AddAsync(IItem entity, HttpPostedFileBase image);

        Task DeleteAsync(IItem entity);

        Task EditAsync(IItem entity, HttpPostedFileBase image);
    }
}
