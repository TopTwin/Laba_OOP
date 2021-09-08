using Laba_OOP.Storage;
using Laba4._5_OOP.Storage.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laba4._5_OOP.Manager.Workers
{
    public class WorkerManager:IWorkerManager
    {
        private readonly LibraryDataContext _dbContext;

        public WorkerManager(LibraryDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyCollection<Worker>> FindOnName(string Name)
        {
            var entities = await (from w in _dbContext.Workers
                                  where w.Name == Name
                                  select w)
                                  .Include(w => w.Library)
                                  .ToListAsync();
            return entities;
        }
        public async Task<IReadOnlyCollection<Worker>> FindOnPosition(string Position)
        {
            var entities = await (from w in _dbContext.Workers
                                  where w.Position == Position
                                  select w).Include(w => w.Library)
                                  .ToListAsync();
            return entities;
        }
        public async Task<IReadOnlyCollection<Worker>> FindOnNameAndPosition(string Name, string Position)
        {
            var entities = await (from w in _dbContext.Workers
                                  where w.Name == Name
                                  where w.Position == Position
                                  select w).Include(w => w.Library)
                                  .ToListAsync();
            return entities;
        }
        public async Task<IReadOnlyCollection<Worker>> FindOnLib(string NameLib)
        {
            var entities = await(from w in _dbContext.Workers
                                 where w.Library.Name == NameLib
                                 select w).Include(w => w.Library)
                                  .ToListAsync();
            return entities;
        }
        public async Task<IReadOnlyCollection<Worker>> GetAll()
        {
            var entities = await _dbContext.Workers.Include(w=>w.Library)
                           .ToListAsync();

            return entities;        
        }

        public async Task<IReadOnlyCollection<Worker>> GetAllOfLibrary(Guid id_library)
        {
            var entities = await (from Worker in _dbContext.Workers
                            where Worker.LibraryId == id_library
                            select Worker).Include(w=>w.Library).ToListAsync();
            return entities;
        }

        public void DeleteWorker(Guid id)
        {
            var entity = _dbContext.Workers.Find(id);
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }

        public Worker GetById(Guid id)
        {
            var entity = (from Worker in _dbContext.Workers
                          where Worker.Id == id
                          select Worker).Include(w => w.Library).Single();
            return entity;
        }

        public async Task<Worker> AddWorker(Guid id_lib,CreateOrUpdateWorker request)
        {
            var entity = new Worker
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Position = request.Position,
                Salary = request.Salary,
                LibraryId = id_lib
            };
            _dbContext.Workers.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Worker> UpdateWorker(Guid id,CreateOrUpdateWorker request)
        {
            var entity = _dbContext.Workers.Find(id);

            entity.Name = request.Name;
            entity.Position = request.Position;
            entity.Salary = request.Salary;
           
            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
