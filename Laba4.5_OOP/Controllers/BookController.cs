using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laba4._5_OOP.Manager.Authors;
using Laba4._5_OOP.Manager.Books;
using Laba4._5_OOP.Manager.Categorys;
using Laba4._5_OOP.Storage;
using Laba4._5_OOP.Storage.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;

namespace Laba4._5_OOP.Controllers
{
    public class BookController : Controller
    {
       private readonly IBookManager _BookManager;
        private readonly IAuthorManager _authorManager;
        private readonly ICategoryManager _categoryManager;
       public BookController(IBookManager BookManager,
                             IAuthorManager authorManager,
                             ICategoryManager categoryManager)
       {
           _BookManager = BookManager;
            _authorManager = authorManager;
            _categoryManager = categoryManager;
        }

        [HttpPost]
        public ActionResult ListBooks(string NameView)
        {
            return RedirectToAction(NameView);
        }
        [HttpGet]
        public async Task<ViewResult> ListAllBooks()
       {
           var entity = await _BookManager.GetAll();
           ViewBag.Count = entity.Count;
           return View(entity);
       }

        [HttpGet]
        public async Task<ViewResult> ListBooksAuthor(Guid id_author)
        {
            var entity = await _BookManager.GetAllAuthor(id_author);
            ViewBag.Count = entity.Count;
            return View(entity);
        }

        [HttpPost]
        public ActionResult GoingToCategory(Guid id_lib,Guid id)
        {
            BufferData.libraryId = id_lib;
            BufferData.id_category = id;
            return RedirectToAction(nameof(ListBooksCategory));
        }

        [HttpGet]
        public async Task<ViewResult> ListBooksLibrary()
        {
            var entity = await _BookManager.GetAllLib(BufferData.libraryId);
            BufferData.NameView = "ListBooksLibrary";
            ViewBag.Count =entity.Count;

            return View(entity);
        }
        [HttpGet]
        public async Task<ViewResult> ListBooksCategory()
        {
            var entity = await _BookManager.GetAllCategory(BufferData.id_category);
            ViewBag.CategoryName = _categoryManager.TakeCategory(BufferData.id_category).Name;
            BufferData.NameView = "ListBooksCategory";
            ViewBag.Count =entity.Count;

            return View(entity);
        }

        [HttpPost]
        public ActionResult FindBook(string requiredName,string requiredAuthor)
        {
            if (requiredAuthor == null && requiredName == null)
                return RedirectToAction(nameof(ListAllBooks));


            return RedirectToAction(nameof(FindListBooks),new { requiredName= requiredName, 
                                                                requiredAuthor = requiredAuthor });
        }

        [HttpGet]
        public async Task<ViewResult> FindListBooks(string requiredName, string requiredAuthor)
        {
            IReadOnlyCollection<Book> entities = null;
            if (requiredAuthor != null && requiredName != null)
            {
                entities = await _BookManager.FindOnNameAndAuthor(requiredName, requiredAuthor);
            }
            else
            {
                if (requiredAuthor != null)
                {
                    entities = await _BookManager.FindOnAuthor(requiredAuthor);
                }
                if (requiredName != null)
                {
                    entities = await _BookManager.FindOnName(requiredName);
                }
            }
            ViewBag.Count = entities.Count;
            return View(entities);
        }

        [HttpPost]
        public ActionResult Delete(Guid id,string NameView)
        {
            _BookManager.DeleteBook(id);
            return RedirectToAction(NameView);
        }

        [HttpPost]
        public async Task<ActionResult> Add()
        {
            string NameView = BufferData.NameView;
            if (BufferData.NameBook == null ||
               BufferData.id_author.ToString() == "00000000-0000-0000-0000-000000000000"||
               BufferData.id_category.ToString() == "00000000-0000-0000-0000-000000000000")
            {
                return RedirectToAction(nameof(AddingPage));
            }

           await _BookManager.AddBook(BufferData.id_author,
                                BufferData.id_category,
                                BufferData.NameBook);
            BufferData.NameBook = null;
            BufferData.id_author = Guid.Empty;
            return RedirectToAction(NameView);
        }

        [HttpPost]
        public ActionResult AddBook(string NameView)
        {
            BufferData.ViewBookUpdateOrAdd = "AddingPage";
            return RedirectToAction(nameof(AddingPage));
        }
        [HttpGet]
        public ViewResult AddingPage()
        {
            ViewBag.BookName = BufferData.NameBook;
            var author = _authorManager.TakeAuthor(BufferData.id_author);
            var category = _categoryManager.TakeCategory(BufferData.id_category);

            if (author != null)
                ViewBag.BookAuthor = author.Name;
            else
                ViewBag.BookAuthor = null;
            
            if (category != null)
                ViewBag.BookCategory = category.Name;
            else
                ViewBag.BookCategory = null;

            return View();
        }

        
        [HttpPost]
        public async Task<ViewResult> NameBook()
        {
            var Book = await _BookManager.TakeBook(BufferData.id_book);
            return View(Book); 
        }
        [HttpPost]
        public ActionResult AddNameBook(string name)
        {
            BufferData.NameBook = name;
            if(BufferData.ViewBookUpdateOrAdd == "AddingPage")
                return RedirectToAction(nameof(AddingPage));
            if(BufferData.ViewBookUpdateOrAdd == "UpdatePage")
                return RedirectToAction(nameof(UpdatePage));

            return RedirectToAction(nameof(AddingPage));
        }
        [HttpPost]
        public ActionResult AddAuthorBook(Guid id_author)
        {
            BufferData.id_author = id_author; 
            
            if (BufferData.ViewBookUpdateOrAdd == "AddingPage")
                return RedirectToAction(nameof(AddingPage));
            if (BufferData.ViewBookUpdateOrAdd == "UpdatePage")
                return RedirectToAction(nameof(UpdatePage));

            return RedirectToAction(nameof(AddingPage));
        }
        [HttpGet]
        public async Task<ViewResult> ListAuthors()
        {
            var entities = await _authorManager.GetAll();
            ViewBag.Count = entities.Count;
            return View(entities);
        }
        [HttpPost]
        public ActionResult AddCategoryBook(Guid id_category)
        {
            BufferData.id_category = id_category;
            if (BufferData.ViewBookUpdateOrAdd == "AddingPage")
                return RedirectToAction(nameof(AddingPage));
            if (BufferData.ViewBookUpdateOrAdd == "UpdatePage")
                return RedirectToAction(nameof(UpdatePage));

            return RedirectToAction(nameof(AddingPage));
        }
        [HttpGet]
        public async Task<ViewResult> ListCategory()
        {
            var entities = await _categoryManager.GetAllLib(BufferData.libraryId);
            ViewBag.Count = entities.Count;
            return View(entities);
        }

        [HttpPost]
        public ViewResult AddCategory()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddingCategory(string Name)
        {
            await _categoryManager.AddCategory(BufferData.libraryId, Name);

            return RedirectToAction(nameof(ListCategory));
        }

        
        public ViewResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddingAuthor(CreateOrUpdateAuthor request)
        {
            await _authorManager.AddAuthor(request);
            return RedirectToAction(nameof(ListAuthors));
        }

        [HttpPost]
        public ActionResult UpdateBook(string NameBook,Guid IdBook,
                                        Guid Category,Guid Author)
        {
            BufferData.id_book = IdBook;
            BufferData.NameBook = NameBook;
            BufferData.id_category = Category;
            BufferData.id_author = Author;
            BufferData.ViewBookUpdateOrAdd = "UpdatePage";
            return RedirectToAction(nameof(UpdatePage));
        }

        [HttpGet]
        public ViewResult UpdatePage()
        {
            ViewBag.BookName = BufferData.NameBook;
            var author = _authorManager.TakeAuthor(BufferData.id_author);
            var category = _categoryManager.TakeCategory(BufferData.id_category);

            if (author != null)
                ViewBag.BookAuthor = author.Name;
            else
                ViewBag.BookAuthor = null;

            if (category != null)
                ViewBag.BookCategory = category.Name;
            else
                ViewBag.BookCategory = null;

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Update()
        {
            await _BookManager.UpdateBook(BufferData.id_book,
                                             BufferData.NameBook,
                                             BufferData.id_author,
                                             BufferData.id_category);
            return RedirectToAction(nameof(ListBooksCategory));
        }
        public IActionResult Index()
       {
           return View();
       }
    }
}