using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laba4._5_OOP.Manager.Categorys;
using Laba4._5_OOP.Storage;
using Microsoft.AspNetCore.Mvc;

namespace Laba4._5_OOP.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryManager _categoryManager;

        public CategoryController(ICategoryManager categorymanager)
        {
            _categoryManager = categorymanager;
        }

        [HttpGet]
        public async Task<ViewResult> ListAllCategories()
        {
            var entity = await _categoryManager.GetAll();
            ViewBag.Count = Convert.ToString(entity.Count);
            return View(entity);
        }
        [HttpGet]
        public async Task<ViewResult> ListCategoriesLib()
        {
            var entity = await _categoryManager.GetAllLib(BufferData.libraryId);
            ViewBag.Count = entity.Count;
            return View(entity);
        }

        public ViewResult AddCategory(string NameView)
        {
            ViewBag.NameView = NameView;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(string Name, string NameView)
        {
            await _categoryManager.AddCategory(BufferData.libraryId,Name);

            return RedirectToAction(NameView);
        }

        public ActionResult Delete(Guid id, string NameView)
        {
            _categoryManager.DeleteCategory(id);

            return RedirectToAction(NameView);
        }

        [HttpGet]
        public ViewResult UpdateCategory(Guid id)
        {
            
            var entity = _categoryManager.TakeCategory(id);
            return View(entity);
        }

        [HttpPost]
        public async Task<ActionResult> Update(Guid id, string Name)
        {
            await _categoryManager.UpdateCategory(id, Name);
            return RedirectToAction(nameof(ListCategoriesLib));
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
