using LevelTwo.Model.Common;
using LevelTwo.Repository.Common;
using LevelTwo.Service.Common;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LevelTwo.Service
{
    public class ItemService : IItemService
    {
        IItemRepository repo;

        public ItemService(IItemRepository repo)
        {
            this.repo = repo;
        }

        public async Task AddAsync(IItem entity, HttpPostedFileBase image)
        {
            InsertImage(entity, image);
            await repo.AddAsync(entity);
        }

        public async Task DeleteAsync(IItem entity)
        {
            DeleteImage(entity);
            await repo.DeleteAsync(entity);
        }

        public async Task EditAsync(IItem entity, HttpPostedFileBase image)
        {
            InsertImage(entity, image);
            DeleteImage(entity);
            await repo.EditAsync(entity);
        }

        public async Task<IItem> GetAsync(int id)
        {
           return await repo.GetAsync(id);
        }

        public async Task<IPagedList<IItem>> GetListAsync(int? page, string search, string priceorder, string discount)
        {
            return await repo.GetListAsync(page, search, priceorder, discount);
        }

        public IItem InsertImage(IItem item, HttpPostedFileBase image)
        {
            if (image != null)
            {
                var nameWithoutExtension = Path.GetFileNameWithoutExtension(image.FileName);
                var Extension = Path.GetExtension(image.FileName);
                item.ImagePath = nameWithoutExtension + DateTime.Now.ToString("MMddyyHmmss") + Extension;
                var path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Images/"), item.ImagePath);
                image.SaveAs(path);
            }
            else
            {
                item.ImagePath = "defaultItem.png";
            }
            return item;
        }

        public void DeleteImage(IItem item)
        {
            var path = System.Web.HttpContext.Current.Request.MapPath("~/Images/" + item.ImagePath);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }

    }
}
