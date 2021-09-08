using Laba4._5_OOP.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laba4._5_OOP.Manager.Workers
{
    public interface IWorkerManager
    {
        public Task<IReadOnlyCollection<Worker>> FindOnName(string Name);
        public Task<IReadOnlyCollection<Worker>> FindOnPosition(string Position);
        public Task<IReadOnlyCollection<Worker>> FindOnNameAndPosition(string Name, string Position);
        public Task<IReadOnlyCollection<Worker>> FindOnLib(string NameLib);
        public Task<IReadOnlyCollection<Worker>> GetAll();
        public Task<IReadOnlyCollection<Worker>> GetAllOfLibrary(Guid id_library);
        public void DeleteWorker(Guid id);
        public Worker GetById(Guid id);
        public Task<Worker> AddWorker(Guid id_lib, CreateOrUpdateWorker request);
        public Task<Worker> UpdateWorker(Guid id, CreateOrUpdateWorker request);
    }
}
