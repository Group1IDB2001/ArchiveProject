﻿using Microsoft.AspNetCore.Mvc;

namespace Archive.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IItemManager _manager;

        public ItemsController(IItemManager manager)
        {
            _manager = manager;
        }

        public async Task<IActionResult> Index(int pg = 1)
        {
            var items = await _manager.GetAllItems();
            int counter = items.Count();
            const int pagesize = 12;
            if (pg < 1) pg = 1;

            var pager = new Pager(counter, pg, pagesize);

            int recSkip = (pg - 1) * pagesize;

            var data = items.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            return View(data);
        }

        [HttpGet]
        
        public async Task<IActionResult> ItemPage(int Id)
        {
            var items = await _manager.GetItemById(Id);

            var data = items;
            
            return View(data);
        }

        [HttpGet]
        
        public async Task<IActionResult> Genre(int id, int pg = 1)
        {
            var items = await _manager.GetItemsByGenre((Genres)id);
            int counter = items.Count();
            const int pagesize = 12;
            if (pg < 1) pg = 1;

            var pager = new Pager(counter, pg, pagesize);

            int recSkip = (pg - 1) * pagesize;

            var data = items.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Description ,Year ,Field, Genre, CountryId")] CreateItemRequest item)
        {
            if (ModelState.IsValid)
            {
                var Item = await _manager.AddItem(item.Name, item.Description, item.Year, item.Field, item.Genre, item.CountryId);
                if (Item)
                    return RedirectToAction("Index");
                else
                {
                    var Item_1 = await _manager.FindItemByName(item.Name);
                    if (Item_1) ModelState.AddModelError("", "Item is already existing");
                }
            }
            return View();
        }



        public async Task<IActionResult> Edit(int id)
        {
            var item = await _manager.GetItemById(id);
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description ,Year ,Field, Genre, CountryId")] Item item)
        {
            var Item = await _manager.EditItem(id, item.Name, item.Description, item.Year, item.Field, item.Genre, item.CountryId);
            if (Item)
                return RedirectToAction("ItemPage", new { Id = id });
            else
            {
                var Item_1 = await _manager.FindItemByName(item.Name);
                if (Item_1) ModelState.AddModelError("", "Item is already existing");
            }
            return View();
        }



        public async Task<IActionResult> Delete(int id)
        {
            var item = await _manager.GetItemById(id);
            return View(item);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _manager.DeleteItem(id);
            if (item) return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError("", "item is already not existing");
                return RedirectToAction("Index");
            }
        }





    }
}


// return RedirectToRoute(new { controller = "Home", action = "Index" });