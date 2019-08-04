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
    public class CategoryController : Controller
    {
        ICategoryService service;

        public CategoryController(ICategoryService service)
        {
            this.service = service;
        }

        // GET: Categories
        public async Task<ActionResult> CategoriesList(int? page, string search)
        {
            page = page ?? 1;
            ViewBag.search = search;
            var categories = await service.GetListAsync(page, search);
            var model = AutoMapper.Mapper.Map<IEnumerable<CategoryVM>>(categories.ToList());
            return View(new StaticPagedList<CategoryVM>(model, categories.GetMetaData()));
        }

        // GET: Categories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryVM category = AutoMapper.Mapper.Map<CategoryVM>(await service.GetAsync((int)id));
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Description")] CategoryVM category)
        {
            if (ModelState.IsValid)
            {
                await service.AddAsync(AutoMapper.Mapper.Map<ICategory>(category));
                return RedirectToAction("CategoriesList");
            }

            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryVM category = AutoMapper.Mapper.Map<CategoryVM>(await service.GetAsync((int)id));
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Description")] CategoryVM category)
        {
            if (ModelState.IsValid)
            {
                await service.EditAsync(AutoMapper.Mapper.Map<ICategory>(category));
                return RedirectToAction("CategoriesList");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryVM category = AutoMapper.Mapper.Map<CategoryVM>(await service.GetAsync((int)id));
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await service.DeleteAsync(await service.GetAsync(id));
            return RedirectToAction("CategoriesList");
        }
    }
}
