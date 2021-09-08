using Laba_OOP.Storage;
using Laba4._5_OOP.Storage.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laba4._5_OOP.Manager.Categorys
{
    public class CategoryManager: ICategoryManager
    {
        private readonly LibraryDataContext _dbContext;

        public CategoryManager(LibraryDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Category> AddCategory(Guid id_lib,string name)
        {
            var entity = new Category
            {
                Id = Guid.NewGuid(),
                Name = name,
                LibraryId = id_lib
            };
            _dbContext.Categories.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<IReadOnlyCollection<Category>> GetAll()
        {
            var query = await _dbContext.Categories.Include(c => c.Library).ToListAsync();

            return query;
        }

        public async Task<IReadOnlyCollection<Category>> GetAllLib(Guid id_lib)
        {
            var query = await (from Category in _dbContext.Categories
                               where Category.LibraryId == id_lib
                               select Category).ToListAsync();
            return query;
        }
        public void DeleteCategory(Guid id)
        {
            var Books = (from b in _dbContext.Books
                         where b.CategoryId == id
                         select b).ToList();
            
            foreach (var item in Books)
            {
                var copybook = (from cp in _dbContext.CopyOfBooks
                                where cp.BookId == item.Id
                                select cp).ToList();

                foreach (var cp in copybook)
                {
                    _dbContext.CopyOfBooks.Remove(cp);
                }

                _dbContext.Books.Remove(item);
            }

            var entity = _dbContext.Categories.Find(id);
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }

        public Category TakeCategory(Guid id)
        {
            return _dbContext.Categories.FirstOrDefault(g => g.Id == id);
        }

        public async Task<Category> UpdateCategory(Guid id, string name)
        {
            var entity = await _dbContext.Categories.FirstOrDefaultAsync(r => r.Id == id);

            entity.Name = name;
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
