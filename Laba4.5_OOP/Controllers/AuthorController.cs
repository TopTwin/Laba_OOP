using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laba4._5_OOP.Manager.Authors;
using Laba4._5_OOP.Storage;
using Microsoft.AspNetCore.Mvc;

namespace Laba4._5_OOP.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorManager _authorManager;

        public AuthorController(IAuthorManager authorManager)
        {
            _authorManager = authorManager;
        }

        [HttpGet]
        public async Task<ViewResult> ListAllAuthors()
        {
            var entity = await _authorManager.GetAll();
            ViewBag.Count = entity.Count;
            return View(entity);
        }

        public ViewResult AddAuthor(string NameView)
        {
            ViewBag.NameView = NameView;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(CreateOrUpdateAuthor request, string NameView)
        {
            await _authorManager.AddAuthor(request);

            return RedirectToAction(NameView);
        }

        
        public ActionResult Delete(Guid id)
        {
            _authorManager.DeleteAuthor(id);

            return RedirectToAction(nameof(ListAllAuthors));
        }

        [HttpGet]
        public ViewResult UpdateAuthor(Guid id)
        {
            var entity = _authorManager.TakeAuthor(id);
            return View(entity);
        }

        [HttpPost]
        public async Task<ActionResult> Update(Guid id, CreateOrUpdateAuthor request)
        {
            await _authorManager.UpdateAuthor(id, request);
            return RedirectToAction(nameof(ListAllAuthors));
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
