using Laba_OOP.Manager.Readers;
using Laba_OOP.Storage;
using Laba4._5_OOP.Storage;
using Laba4._5_OOP.Storage.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using System.Threading.Tasks;

namespace Laba4._5_OOP.Manager.Books
{
    public class BookManager : IBookManager
    {
        private readonly LibraryDataContext _dbContext;


        public BookManager(LibraryDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Book> UpdateBook(Guid id,string Name,Guid id_aut,Guid id_cat)
        {
            var entity =await _dbContext.Books.FirstOrDefaultAsync(g => g.Id == id);

            var category = await _dbContext.Categories.FindAsync(entity.CategoryId);//Находим предыдущую категорию книги
            category.Quantity--;//уменьшаем количесвто книг

            entity.Name = Name;
            entity.CategoryId = id_cat;
            entity.AuthorId = id_aut; 

            category = await _dbContext.Categories.FindAsync(id_cat);//находим новую категорию книги
            category.Quantity++;//увеличиваем количество книг 

            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IReadOnlyCollection<Book>> FindOnName(string Name)
        {
            var entity = await (from b in _dbContext.Books
                                 where b.Name == Name
                                select b).Include(b => b.author)
                                .Include(b => b.category)
                                .Include(b => b.category.Library)
                                .ToListAsync();
            return entity;
        }
        public async Task<IReadOnlyCollection<Book>> FindOnAuthor(string Author)
        {
            var entity = await (from b in _dbContext.Books
                                where b.author.Name == Author
                                select b).Include(b => b.author)
                                .Include(b => b.category)
                                .Include(b => b.category.Library)
                                .ToListAsync();
            return entity;
        }
        public async Task<IReadOnlyCollection<Book>> FindOnNameAndAuthor(string Name, string Author)
        {
            var entity = await (from b in _dbContext.Books
                                where b.Name == Name
                                where b.author.Name == Author
                                select b)
                                .Include(b => b.author)
                                .Include(b => b.category)
                                .Include(b => b.category.Library)
                                .ToListAsync();
            return entity;
        }
        public async Task<Book> AddBook(Guid id_aut,Guid id_cat,string NameBook)
        {
            var entity = new Book
            {
                Name = NameBook,
                AuthorId = id_aut,
                CategoryId = id_cat
            };
            var category = await _dbContext.Categories.FindAsync(id_cat);
            category.Quantity++;
            _dbContext.Books.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task<IReadOnlyCollection<Book>> GetAll()
        {
            var query = await _dbContext.Books.Include(b=>b.author)
                                .Include(b=>b.category)
                                .Include(b=>b.category.Library)
                                .ToListAsync();
        
            return query;
        }

        public async Task<IReadOnlyCollection<Book>> GetAllAuthor(Guid id_author)
        {
            var query = await (from Book in _dbContext.Books
                               where Book.AuthorId == id_author
                               select Book).Include(b => b.author)
                                .Include(b => b.category).ToListAsync();

            return query;
        }

        public async Task<IReadOnlyCollection<Book>> GetAllCategory(Guid id_category)
        {
            var query = await (from Book in _dbContext.Books
                               where Book.CategoryId == id_category
                               select Book)
                               .Include(b => b.author)
                               .Include(b => b.category)
                               .ToListAsync();

            return query;
        }

        public async Task<IReadOnlyCollection<Book>> GetAllLib(Guid id_lib)
        {
            var query = await (from Book in _dbContext.Books
                               where Book.category.LibraryId == id_lib
                               select Book)
                              .Include(b => b.author)
                              .Include(b => b.category)
                              .ToListAsync();

            return query;
        }

        public void DeleteBook(Guid id_delete)
        {
            var entity = (from Book in _dbContext.Books
                         where Book.Id == id_delete
                         select Book).Single();

            var CopyOfBooks = (from CP in _dbContext.CopyOfBooks
                               where CP.BookId == entity.Id
                               select CP).ToList();
            foreach(var item in CopyOfBooks)
            {
                _dbContext.CopyOfBooks.Remove(item);
            }

            var category = _dbContext.Categories.Find(entity.CategoryId);
            category.Quantity--;

           _dbContext.Remove(entity);
           _dbContext.SaveChanges();
        }

        public async Task<Book> TakeBook(Guid id_Book)
        {
            return await _dbContext.Books.FirstOrDefaultAsync(g => g.Id == id_Book);
        }

    }
}
