using Laba_OOP.Storage;
using Laba4._5_OOP.Manager.Authors;
using Laba4._5_OOP.Storage.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laba4._5_OOP.Manager.Authors
{
    public class AuthorManager:IAuthorManager
    {
        private readonly LibraryDataContext _dbContext;

        public AuthorManager(LibraryDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Author> AddAuthor(CreateOrUpdateAuthor request)
        {
            var entity = new Author
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                DateLife = request.DateLife,
                Biography = request.Biography
            };
            _dbContext.Authors.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<IReadOnlyCollection<Author>> GetAll()
        {
            var query = await _dbContext.Authors.ToListAsync();

            return query;
        }

        public void DeleteAuthor (Guid id)
        {
            var Books = (from b in _dbContext.Books
                              where b.AuthorId == id
                              select b).ToList();


            foreach(var item in Books)
            {
                var copybook = (from cp in _dbContext.CopyOfBooks
                          where cp.BookId == item.Id
                          select cp).ToList();

                foreach (var cp in copybook)
                {
                    _dbContext.CopyOfBooks.Remove(cp);
                }

                var category = _dbContext.Categories.Find(item.CategoryId);
                category.Quantity--;

                _dbContext.Books.Remove(item);
            }
            var entity = _dbContext.Authors.Find(id);
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }

        public Author TakeAuthor(Guid id)
        {
            return _dbContext.Authors.FirstOrDefault(g => g.Id == id);
        }

        public async Task<Author> UpdateAuthor(Guid id, CreateOrUpdateAuthor request)
        {
            var entity = await _dbContext.Authors.FirstOrDefaultAsync(r => r.Id == id);

            entity.Name = request.Name;
            entity.DateLife = request.DateLife;
            entity.Biography = request.Biography;
            await _dbContext.SaveChangesAsync();
             return entity;
        }
    }
}
