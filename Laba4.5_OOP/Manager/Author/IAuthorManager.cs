using Laba4._5_OOP.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laba4._5_OOP.Manager.Authors
{
    public interface IAuthorManager
    {
        public Task<Author> AddAuthor(CreateOrUpdateAuthor request);
        public Task<IReadOnlyCollection<Author>> GetAll();
        public void DeleteAuthor(Guid id);
        public Author TakeAuthor(Guid id);
        public Task<Author> UpdateAuthor(Guid id, CreateOrUpdateAuthor request);
    }
}
