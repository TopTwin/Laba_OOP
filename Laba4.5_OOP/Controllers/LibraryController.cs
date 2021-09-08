using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laba4._5_OOP.Manager.Librarys;
using Laba4._5_OOP.Storage;
using Microsoft.AspNetCore.Mvc;

namespace Laba4._5_OOP.Controllers
{
    public class LibraryController : Controller
    {
        ILibraryManager libraryManager;

        public LibraryController(ILibraryManager _libraryManager)
        {
            libraryManager = _libraryManager;
        }

        [HttpGet]
        public async Task<ViewResult> ListOfLibrary()
        {
            var entities = await libraryManager.GetAll();
            return View(entities);
        }


        public ViewResult AddLibrary()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(string name)
        {
            await libraryManager.AddLibrary(name);
            return RedirectToAction(nameof(ListOfLibrary));
        }

        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            libraryManager.DeleteLibrary(id);
            return RedirectToAction(nameof(ListOfLibrary));
        }

        [HttpGet]
        public ViewResult PageOfLibrary()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TakingLibrary(Guid id)
        {
            BufferData.libraryId = id;
            return RedirectToAction(nameof(PageOfLibrary));
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
