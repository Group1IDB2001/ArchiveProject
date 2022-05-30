﻿using ArchiveLogic.CollectionItems;
using Microsoft.AspNetCore.Mvc;

namespace Archive.Controllers
{
    public class CollectionItemController : Controller
    {
        private readonly ICollectionItemManager _manager;

        public CollectionItemController(ICollectionItemManager manager)
        {
            _manager = manager;
        }
        [HttpGet]
        public async Task<IActionResult> ShowItems(int id)
        {
            var lis = await _manager.GetItemCollectionByCollection(id);
            if(lis == null)
            {
                GlobalData.ids.Clear();
                return Redirect("/Items/ItemsIn");
            }
            else
            {
                GlobalData.ids.Clear();
                int ii;
                foreach (var col in lis)
                {
                    if (col.ItemId != null)
                    {
                        ii = ((int)col.ItemId);
                        GlobalData.ids.Add(ii);
                    }
                }
                return Redirect("/Items/ItemsIn");
            }
            
        }

        public async Task<IActionResult> PickItem(int id)
        {
            GlobalData.cid = id;
            return Redirect("/Items/PickItem");
        }

        public async Task<IActionResult> AddItem(int id)
        {
            var coolec = await _manager.AddCollectionItem(GlobalData.cid, id);
            if (coolec)
                return Redirect("/Collection/CollectionsPage");
            else
            {
                var coolect_1 = await _manager.FindCollectionItem(GlobalData.cid, id);
                if (coolect_1) ModelState.AddModelError("","Collection with this item is already existing");
            }
            return View();

        }

       
    }
}
