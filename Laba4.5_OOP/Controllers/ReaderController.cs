using Laba_OOP.Manager.Readers;
using Laba_OOP.Storage.Entity;
using Laba4._5_OOP.Manager.Books;
using Laba4._5_OOP.Storage;
using Laba4._5_OOP.Storage.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Laba_OOP.Controllers
{

    
    public class ReaderController : Controller
    {
        private readonly IReaderManager _readerManager;
        private readonly IBookManager _bookManager;
        public ReaderController(IReaderManager readerManager, IBookManager bookManager)
        {
            _readerManager = readerManager;
            _bookManager = bookManager;
        }

        [HttpGet]
        public async Task<ViewResult> ListReaders()
        {
            var entity = await _readerManager.GetAll();
            ViewBag.Count = Convert.ToString(entity.Count);
            return View(entity);
        }

        [HttpGet]
        public async Task<ViewResult> ListReadersLib()
        {
            var entity = await _readerManager.GetAllLibrary(BufferData.libraryId);
            ViewBag.Count = entity.Count;
            return View(entity);
        }

        [HttpPost]
        public ActionResult FindReader(string Name, string LastName)
        {
            if (Name == null && LastName == null)
                return RedirectToAction(nameof(ListReadersLib));

            return RedirectToAction(nameof(FindListReader), new
            {
                Name = Name,
                LastName = LastName
            });
        }
        [HttpGet]
        public async Task<ViewResult> FindListReader(string Name,string LastName)
        {
            IReadOnlyCollection<Reader> entities = null;
            if (Name != null && LastName != null)
            {
                entities = await _readerManager.FindOnNameAndLastName(Name, LastName);
            }
            else
            {
                if (Name != null)
                {
                    entities = await _readerManager.FindOnName(Name);
                }
                if (LastName != null)
                {
                    entities = await _readerManager.FindOnLastName(LastName);
                }
            }
            ViewBag.Count = entities.Count;
            return View(entities);
        }
        public ViewResult AddReader(string NameView)
        {
            ViewBag.NameView = NameView;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(CreateOrUpdateReaderRequest request, string NameView)
        {
            await _readerManager.AddReader(BufferData.libraryId,request);

            return RedirectToAction(NameView);
        }

        public ActionResult Delete(Guid id_delete_reader, string NameView)
        {
            _readerManager.DeleteReader(id_delete_reader);

            return RedirectToAction(NameView);
        }

        [HttpGet]
        public ViewResult PageOfReader()
        {
            Guid id_reader = BufferData.id_reader;
            var request = _readerManager.TakeReader(id_reader);
            var BooksOfReader = _readerManager.BooksOfReader(id_reader);

            ViewBag.Count = BooksOfReader.Count;
            ViewBag.Books = BooksOfReader;
            return View(request);
        }

        public ActionResult TakingReader(Guid id_reader)
        {
            BufferData.id_reader = id_reader;
            return RedirectToAction(nameof(PageOfReader));
        }

        public async Task<ViewResult> AddBookForReader()
        {
            var books = await _bookManager.GetAllLib(BufferData.libraryId) ;
             ViewBag.Count = books.Count;
            return View(books);
        }

        public ActionResult AddBook(Guid id_book)
        {
            _readerManager.AddingBook(id_book, BufferData.id_reader);
            return RedirectToAction(nameof(PageOfReader));
        }

        public ActionResult DeleteBook(Guid id_book)
        {
            _readerManager.DeletingBook(id_book);
            return RedirectToAction(nameof(PageOfReader));
        }

        [HttpGet]
        public ViewResult UpdateReader(Guid id)
        {
            var entity = _readerManager.TakeReader(id);
            return View(entity);
        }

        [HttpPost]
        public async Task<ActionResult> Update(Guid id_reader, CreateOrUpdateReaderRequest request)
        {
            await _readerManager.UpdateReader(id_reader, request);
            return RedirectToAction(nameof(PageOfReader));
        }
    }
}