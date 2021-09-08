using Laba_OOP.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laba4._5_OOP.Storage.Entity;
using Microsoft.EntityFrameworkCore;

namespace Laba4._5_OOP.Manager.Librarys
{
    public class LibraryManager: ILibraryManager
    {
        private readonly LibraryDataContext _dbContext;

        public LibraryManager(LibraryDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyCollection<Library>> GetAll()
        {
            var entities = await _dbContext.Libraries.ToListAsync();
            return entities;
        }

        public async Task<Library> AddLibrary(string name)
        {
            var entity = new Library
            {
                Id = Guid.NewGuid(),
                Name = name
            };

            _dbContext.Libraries.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public void DeleteLibrary(Guid id_delete)
        {
            var query = (from Reader in _dbContext.Readers
                              where Reader.LibraryId == id_delete
                              select Reader).ToList();
            foreach(var item in query)
            {
                _dbContext.Readers.Remove(item);
            }
            var entity = _dbContext.Libraries.Find(id_delete);
            _dbContext.Libraries.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
