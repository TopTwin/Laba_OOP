using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laba4._5_OOP.Manager.CopyOfBooks;
using Laba4._5_OOP.Storage;
using Microsoft.AspNetCore.Mvc;

namespace Laba4._5_OOP.Controllers
{
    public class CopyOfBookController : Controller
    {
        private ICopyOfBookManager _copyOfBookManager;
        public CopyOfBookController(ICopyOfBookManager copyOfBookManager)
        {
            _copyOfBookManager = copyOfBookManager;
        }
        public async Task<ViewResult> ListCopyOfBook()
        {
            var entity = await _copyOfBookManager.GetAll(BufferData.libraryId);
            return View(entity);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
