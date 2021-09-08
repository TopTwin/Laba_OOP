using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laba_OOP.Manager.Readers;
using Microsoft.AspNetCore.Mvc;

namespace Laba_OOP.Controllers
{
    public class MainController : Controller
    {
        IReaderManager _readerManager;

        public MainController(IReaderManager readerManager)
        {
            _readerManager = readerManager;
        }
        public ViewResult MainPage()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}