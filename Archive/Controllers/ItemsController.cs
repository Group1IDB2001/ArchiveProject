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

        public async Task<IActionResult> PickItem(int pg = 1)
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

        public async Task<IActionResult> PickItemTag(int pg = 1)
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
            GlobalData.iid = Id;
            return Redirect("/Authors/AuthorList/");
        }

        [HttpGet]
        public async Task<IActionResult> ItemPageW()
        {
            var items = await _manager.GetItemById(GlobalData.iid);
            return View(items);
        }

        [HttpGet]
        public async Task<IActionResult> ItemPageCollectionW()
        {
            var items = await _manager.GetItemById(GlobalData.iid);
            return View(items);
        }

        [HttpGet]
        public async Task<IActionResult> ItemPageCollection(int Id)
        {
            var items = await _manager.GetItemById(Id);
            GlobalData.iid = Id;
            return Redirect("/Authors/AuthorListC/");
        }


        [HttpGet]
        public async Task<IActionResult> ItemPageTage(int Id)
        {
            var items = await _manager.GetItemById(Id);
            return View(items);
        }

        [HttpGet]
        public async Task<IActionResult> ItemPageGanre(int Id)
        {
            var items = await _manager.GetItemById(Id);
            return View(items);
        }


        //from items to tag
        [HttpGet]
        public async Task<IActionResult> ItemsInTage(int pg = 1)
        {
            var items = new List<Item>();
            if(GlobalData.ids.Count() == 0)
            {

                items = null;
                return View(items);
            }
            else
            {
                foreach (var i in GlobalData.ids)
                {
                    items.Add(await _manager.GetItemById(i));
                }
                int counter = items.Count();
                const int pagesize = 12;
                if (pg < 1) pg = 1;

                var pager = new Pager(counter, pg, pagesize);

                int recSkip = (pg - 1) * pagesize;

                var data = items.Skip(recSkip).Take(pager.PageSize).ToList();

                this.ViewBag.Pager = pager;

                return View(data);
            }
            
        }



        //from tag to items 
        [HttpGet]
        public async Task<IActionResult> ItemsInTageItems(int pg = 1)
        {
            var items = new List<Item>();
            if (GlobalData.ids.Count() == 0)
            {

                items = null;
                return View(items);
            }
            else
            {
                foreach (var i in GlobalData.ids)
                {
                    items.Add(await _manager.GetItemById(i));
                }
                int counter = items.Count();
                const int pagesize = 12;
                if (pg < 1) pg = 1;

                var pager = new Pager(counter, pg, pagesize);

                int recSkip = (pg - 1) * pagesize;

                var data = items.Skip(recSkip).Take(pager.PageSize).ToList();

                this.ViewBag.Pager = pager;

                return View(data);
            }

        }























        [HttpGet]
        public async Task<IActionResult> ItemsInCollection(int pg = 1)
        {
            var items = new List<Item>();
            if (GlobalData.ids.Count() == 0)
            {

                items = null;
                return View(items);
            }
            else
            {
                foreach (var i in GlobalData.ids)
                {
                    items.Add(await _manager.GetItemById(i));
                }
                int counter = items.Count();
                const int pagesize = 12;
                if (pg < 1) pg = 1;

                var pager = new Pager(counter, pg, pagesize);

                int recSkip = (pg - 1) * pagesize;

                var data = items.Skip(recSkip).Take(pager.PageSize).ToList();

                this.ViewBag.Pager = pager;

                return View(data);
            }

        }


        //from collection
        [HttpGet]
        public async Task<IActionResult> ItemsInCollectionfromco(int pg = 1)
        {
            var items = new List<Item>();
            if (GlobalData.ids.Count() == 0)
            {

                items = null;
                return View(items);
            }
            else
            {
                foreach (var i in GlobalData.ids)
                {
                    items.Add(await _manager.GetItemById(i));
                }
                int counter = items.Count();
                const int pagesize = 12;
                if (pg < 1) pg = 1;

                var pager = new Pager(counter, pg, pagesize);

                int recSkip = (pg - 1) * pagesize;

                var data = items.Skip(recSkip).Take(pager.PageSize).ToList();

                this.ViewBag.Pager = pager;

                return View(data);
            }

        }





        [HttpGet]
        public async Task<IActionResult> ItemsInCollectionSaved(int pg = 1)
        {
            var items = new List<Item>();
            if (GlobalData.ids.Count() == 0)
            {

                items = null;
                return View(items);
            }
            else
            {
                foreach (var i in GlobalData.ids)
                {
                    items.Add(await _manager.GetItemById(i));
                }
                int counter = items.Count();
                const int pagesize = 12;
                if (pg < 1) pg = 1;

                var pager = new Pager(counter, pg, pagesize);

                int recSkip = (pg - 1) * pagesize;

                var data = items.Skip(recSkip).Take(pager.PageSize).ToList();

                this.ViewBag.Pager = pager;

                return View(data);
            }

        }



        [HttpGet]
        public async Task<IActionResult> ItemsInLikes(int pg = 1)
        {
            var items = new List<Item>();
            if (GlobalData.ids.Count() == 0)
            {

                items = null;
                return View(items);
            }
            else
            {
                foreach (var i in GlobalData.ids)
                {
                    items.Add(await _manager.GetItemById(i));
                }
                int counter = items.Count();
                const int pagesize = 12;
                if (pg < 1) pg = 1;

                var pager = new Pager(counter, pg, pagesize);

                int recSkip = (pg - 1) * pagesize;

                var data = items.Skip(recSkip).Take(pager.PageSize).ToList();

                this.ViewBag.Pager = pager;

                return View(data);
            }

        }


















        [HttpGet]
        
        public async Task<IActionResult> Genre(int id, int pg = 1)
        {
            GlobalData.Gunrid= id;
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
                    if (Item_1) ModelState.AddModelError("", "Каталог уже существует");
                    else ModelState.AddModelError("CountryId", "Этого названия страны не существует! Пожалуйста, введите новое название страны");
                }
            }
            return View();
        }

        public async Task<IActionResult> NotFound()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            GlobalData.iid = id;
            if (GlobalData.uroleid == 3)
            {
                return RedirectToAction("NotFound");
            }
            else
            {
                var item = await _manager.GetItemById(id);
                return View(item);
            }
            
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
                if (Item_1) ModelState.AddModelError("", "Каталог уже существует");

            }
            return View();
        }



        public async Task<IActionResult> Delete(int id)
        {
            GlobalData.iid = id;
            if (GlobalData.uroleid == 3)
            {
                return RedirectToAction("NotFound");
            }
            else
            {
                var item = await _manager.GetItemById(id);
                return View(item);
            }
                
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _manager.DeleteItem(id);
            if (item) return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError("", "Каталог уже существует");
                return RedirectToAction("Index");
            }
        }


        public async Task<IActionResult> ReyurntoItemPage(int id)
        {
            var items = await _manager.GetItemsByAuthorId(id);
            return RedirectToAction("ItemPage", new { Id = items[0].Id });
        }


        public async Task<IActionResult> Searching (string searching)
        {
            var items = await _manager.GetItemByName(searching);
            if(items.Count() == 0)
            {
                items = await _manager.GetItemsByAuthorName(searching);
            }
            return View(items);

        }
    }
}
