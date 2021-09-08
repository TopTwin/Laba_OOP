using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laba4._5_OOP.Manager.Workers;
using Laba4._5_OOP.Storage;
using Laba4._5_OOP.Storage.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Laba4._5_OOP.Controllers
{
    public class WorkerController : Controller
    {

        private readonly IWorkerManager _workerManager;
        public WorkerController(IWorkerManager workerManager)
        {
            _workerManager = workerManager;
        }

        [HttpGet]
        public async Task<ViewResult> AllListWorkers()
        {
            var entities = await _workerManager.GetAll();
            ViewBag.Count = entities.Count;
            return View(entities);
        }
        [HttpPost]
        public ActionResult FindNamePosWorker(string Name,string Position)
        {
            if (Name == null && Position == null)
                return RedirectToAction(nameof(AllListWorkers));

            return RedirectToAction(nameof(FindListNamePosWorkers), new
            {
                Name = Name,
                Position = Position
            });
        }
        [HttpGet]
        public async Task<ViewResult> FindListNamePosWorkers(string Name, string Position)
        {
            IReadOnlyCollection<Worker> entities = null;
            if (Name != null && Position != null)
            {
                entities = await _workerManager.FindOnNameAndPosition(Name, Position);
            }
            else
            {
                if (Name != null)
                {
                    entities = await _workerManager.FindOnName(Name);
                }
                if (Position != null)
                {
                    entities = await _workerManager.FindOnPosition(Position);
                }
            }
            ViewBag.Count = entities.Count;

            return View(entities);
        }
       // [HttpPost]
       // public ActionResult FindLib(string NameLib)
       // {
       //     if (NameLib == null)
       //         return RedirectToAction(nameof(AllListWorkers));
       //
       //     return RedirectToAction(nameof(FindOnLibListWorkers), new { NameLib = NameLib });
       // }
       // [HttpGet]
       // public async Task<ViewResult> FindOnLibListWorkers(string NameLib)
       // {
       //     IReadOnlyCollection<Worker> entities = null;
       //     if(NameLib != null)
       //     {
       //         entities = await _workerManager.FindOnLib(NameLib);
       //     }
       //
       //     ViewBag.Count = entities.Count;
       //     return View(entities);
       // }
        [HttpGet]
        public async Task<ViewResult> ListLibraryWorkers()
        {
            var entities = await _workerManager.GetAllOfLibrary(BufferData.libraryId);
            ViewBag.Count = entities.Count;
            return View(entities);
        }

        public ViewResult AddWorkerLib()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddLib(CreateOrUpdateWorker request)
        {
            await _workerManager.AddWorker(BufferData.libraryId, request);
            return RedirectToAction(nameof(ListLibraryWorkers));
        }

        public ActionResult Delete(Guid id)
        {
            _workerManager.DeleteWorker(id);
            return RedirectToAction(nameof(AllListWorkers));
        }

        public ActionResult DeleteLib(Guid id)
        {
            _workerManager.DeleteWorker(id);
            return RedirectToAction(nameof(ListLibraryWorkers));
        }

        [HttpGet]
        public ViewResult UpdateWorker(Guid id)
        {
            var entity = _workerManager.GetById(id);
            return View(entity);
        }

        [HttpGet]
        public ViewResult UpdateWorkerLib(Guid id)
        {
            var entity = _workerManager.GetById(id);
            return View(entity);
        }

        [HttpPost]
        public async Task<ActionResult> Update(Guid id,CreateOrUpdateWorker request)
        {
            await _workerManager.UpdateWorker(id, request);
            return RedirectToAction(nameof(AllListWorkers));
        }

        [HttpPost]
        public async Task<ActionResult> UpdateLib(Guid id, CreateOrUpdateWorker request)
        {
            await _workerManager.UpdateWorker(id, request);
            return RedirectToAction(nameof(ListLibraryWorkers));
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
