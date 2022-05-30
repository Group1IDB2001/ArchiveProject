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
            await _manager.AddSaved(GlobalData.uid, id);
            return Redirect("/Save/SavedCollections");
        }

        public async Task<IActionResult> SavedCollections()
        {
            var col = await _manager.GetSavedByUser(GlobalData.uid);
            GlobalData.ids.Clear();
            foreach(var s in col)
            {
                GlobalData.ids.Add((int)s.CollectionId);
            }
            return Redirect("/Collection/Saved");
        }
    }
}
