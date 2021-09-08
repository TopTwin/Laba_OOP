using Laba_OOP.Storage.Entity;
using Laba4._5_OOP.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laba_OOP.Manager.Readers
{
    public interface IReaderManager
    {
        public Task<IReadOnlyCollection<Reader>> FindOnLastName(string LastName);
        public Task<IReadOnlyCollection<Reader>> FindOnName(string Name);
        public Task<IReadOnlyCollection<Reader>> FindOnNameAndLastName(string Name, string LastName);
        public Task<Reader> AddReader(Guid id_library, CreateOrUpdateReaderRequest request);
        public Task<IReadOnlyCollection<Reader>> GetAll();
        public Task<IReadOnlyCollection<Reader>> GetAllLibrary(Guid id_library);
        public void DeleteReader(Guid id_delete);
        public Reader TakeReader(Guid id_reader);
        public List<Book> BooksOfReader(Guid id_reader);
        public void AddingBook(Guid id_book, Guid id_reader);
        public void DeletingBook(Guid id_book);
        public Task<Reader> UpdateReader(Guid id_reader, CreateOrUpdateReaderRequest reader);
    }
}
