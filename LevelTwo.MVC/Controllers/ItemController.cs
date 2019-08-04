using LevelTwo.Model.Common;
using LevelTwo.MVC.Models;
using LevelTwo.Service.Common;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LevelTwo.MVC.Controllers
{
    public class ItemController : Controller
    {
        IItemService service;
        ICategoryService categoryService;

        public ItemController(IItemService service, ICategoryService categoryService)
        {
            this.service = service;
            this.categoryService = categoryService;
        }


        // GET: Items
        public async Task<ActionResult> ItemsList(int? page, string search, string priceorder, string discount)
        {
            page = page ?? 1;
            ViewBag.search = search;
            ViewBag.priceorder = priceorder;
            ViewBag.discount = discount;
            var Items = await service.GetListAsync(page, search, priceorder, discount);
            var model = AutoMapper.Mapper.Map<IEnumerable<ItemVM>>(Items.ToList());
            return View(new StaticPagedList<ItemVM>(model, Items.GetMetaData()));
        }

        // GET: Items/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemVM item = AutoMapper.Mapper.Map<ItemVM>(await service.GetAsync((int)id));
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.CategoryId = new SelectList(AutoMapper.Mapper.Map<IEnumerable<CategoryVM>>(await categoryService.GetListAsync()), "Id", "Name");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Description,Price,Discount,CategoryId")] ItemVM item, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                await service.AddAsync(AutoMapper.Mapper.Map<IItem>(item), image);
                return RedirectToAction("ItemsList");
            }

            ViewBag.CategoryId = new SelectList(AutoMapper.Mapper.Map<IEnumerable<CategoryVM>>(await categoryService.GetListAsync()), "Id", "Name", item.CategoryId);
            return View(item);
        }

        // GET: Items/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemVM item = AutoMapper.Mapper.Map<ItemVM>(await service.GetAsync((int)id));
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(AutoMapper.Mapper.Map<IEnumerable<CategoryVM>>(await categoryService.GetListAsync()), "Id", "Name", item.CategoryId);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Description,Price,Discount,CategoryId")] ItemVM item, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                await service.AddAsync(AutoMapper.Mapper.Map<IItem>(item), image);
                return RedirectToAction("ItemsList");
            }
            ViewBag.CategoryId = new SelectList(AutoMapper.Mapper.Map<IEnumerable<CategoryVM>>(await categoryService.GetListAsync()), "Id", "Name", item.CategoryId);
            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemVM item = AutoMapper.Mapper.Map<ItemVM>(await service.GetAsync((int)id));
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await service.DeleteAsync(await service.GetAsync(id));
            return RedirectToAction("ItemsList");
        }
    }
}
