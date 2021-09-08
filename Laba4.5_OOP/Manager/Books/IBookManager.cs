using Laba4._5_OOP.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laba4._5_OOP.Manager.Books
{
    public interface IBookManager
    {
        public Task<Book> UpdateBook(Guid id, string Name, Guid id_aut, Guid id_cat);
        public Task<Book> AddBook(Guid id_aut, Guid id_cat, string NameBook);
        public Task<IReadOnlyCollection<Book>> FindOnName(string Name);
        public Task<IReadOnlyCollection<Book>> FindOnAuthor(string Author);
        public Task<IReadOnlyCollection<Book>> FindOnNameAndAuthor(string Name, string Author);
        public Task<IReadOnlyCollection<Book>> GetAll();
        public Task<IReadOnlyCollection<Book>> GetAllAuthor(Guid id_author);
        public Task<IReadOnlyCollection<Book>> GetAllCategory(Guid id_category);
        public Task<IReadOnlyCollection<Book>> GetAllLib(Guid id_lib);
        public void DeleteBook(Guid id_delete);
        public Task<Book> TakeBook(Guid id_Book);
    }
}
