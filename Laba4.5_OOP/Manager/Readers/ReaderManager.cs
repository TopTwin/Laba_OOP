using Laba_OOP.Storage;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laba_OOP.Storage.Entity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Data.Services.Client;
using Laba4._5_OOP.Storage.Entity;
using Laba4._5_OOP.Storage;

namespace Laba_OOP.Manager.Readers
{
    public class ReaderManager : IReaderManager
    {

        private readonly LibraryDataContext _dbContext;

        public ReaderManager(LibraryDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Reader> AddReader(Guid id_library,CreateOrUpdateReaderRequest request)
        {
            var entity = new Reader
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                LastName = request.SecondName,
                Registration = DateTime.Now,
                LibraryId = id_library
            };

            _dbContext.Readers.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<IReadOnlyCollection<Reader>> FindOnName(string Name)
        {
            var entity = await (from r in _dbContext.Readers
                                where r.Name == Name
                                select r).ToListAsync();
            return entity;
        }
        public async Task<IReadOnlyCollection<Reader>> FindOnLastName(string LastName)
        {
            var entity = await (from r in _dbContext.Readers
                                where r.LastName == LastName
                                select r).ToListAsync();
            return entity;
        }
        public async Task<IReadOnlyCollection<Reader>> FindOnNameAndLastName(string Name, string LastName)
        {
            var entity = await (from r in _dbContext.Readers
                                where r.Name == Name
                                where r.LastName == LastName
                                select r).ToListAsync();
            return entity;
        }
        public async Task<IReadOnlyCollection<Reader>> GetAll()
        {
            var query = await _dbContext.Readers.ToListAsync();

            return query;
        }

        public async Task<IReadOnlyCollection<Reader>> GetAllLibrary(Guid id_library)
        {
            var query = await (from Reader in _dbContext.Readers
                               where Reader.LibraryId == id_library
                               select Reader).ToListAsync();

            return query;
        }
        public void DeleteReader(Guid id_delete)
        {
           var entity = (from Reader in _dbContext.Readers
                         where Reader.Id == id_delete
                         select Reader).Single();
           
           _dbContext.Remove(entity);
           _dbContext.SaveChanges();
        }

        public Reader TakeReader(Guid id_reader)
        {
            return _dbContext.Readers.FirstOrDefault(g => g.Id == id_reader);
        }

        public List<Book> BooksOfReader(Guid id_reader)
        {
            var buffer = _dbContext.CopyOfBooks.Include(cp => cp.Book.category).Include(cp => cp.Book.author);
            var entitis = (from CopyOfBook in buffer
                           where CopyOfBook.ReaderId == id_reader
                                 select CopyOfBook.Book).ToList();

            return entitis;
        }

        public void AddingBook(Guid id_book, Guid id_reader)
        {
            CopyOfBook Copyofbook = new CopyOfBook
            {
                Id = Guid.NewGuid(),
                BookId = id_book,
                ReaderId = id_reader
            };
            _dbContext.CopyOfBooks.Add(Copyofbook);
            _dbContext.SaveChanges();
        }

        public void DeletingBook(Guid id_book)
        {
            var CopyOfBook = _dbContext.CopyOfBooks.FirstOrDefault(g => g.BookId == id_book);
            _dbContext.Remove(CopyOfBook);
            _dbContext.SaveChanges();
        }

        public async Task<Reader> UpdateReader(Guid id_reader, CreateOrUpdateReaderRequest reader)
        {
            var entity = await _dbContext.Readers.FirstOrDefaultAsync(r => r.Id == id_reader);

            entity.Name = reader.Name;
            entity.LastName = reader.SecondName;

            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
