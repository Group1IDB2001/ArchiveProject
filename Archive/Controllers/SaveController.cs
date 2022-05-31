using ArchiveLogic.Saves;
using Microsoft.AspNetCore.Mvc;

namespace Archive.Controllers
{
    public class SaveController : Controller
    {
        private readonly ISaveManager _manager;

        public SaveController(ISaveManager manager)
        {
            _manager = manager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Save(int id)
        {
            var save=await _manager.AddSaved(GlobalData.uid, id);
            if(save)
                return Redirect("/Save/SavedCollections");
            else
            {
                var save_1 = await _manager.FindSaved(GlobalData.uid, id);
                if (save_1) ModelState.AddModelError("", "Collection is already existing");
                return Redirect("/Save/SavedCollections");
            }
            
        }

        public async Task<IActionResult> SavedCollections()
        {
            var col = await _manager.GetSavedByUser(GlobalData.uid);
            if(col == null)
            {
                GlobalData.ids.Clear();
                return Redirect("/Collection/Saved");
            }
            else
            {
                GlobalData.ids.Clear();
                foreach (var s in col)
                {
                    GlobalData.ids.Add((int)s.CollectionId);
                }
                return Redirect("/Collection/Saved");
            }
           
        }
    }
}
