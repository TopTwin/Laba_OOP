using Laba4._5_OOP.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laba4._5_OOP.Manager.Categorys
{
    public interface ICategoryManager
    {
        public Task<Category> AddCategory(Guid id_lib, string name);
        public Task<IReadOnlyCollection<Category>> GetAll();
        public Task<IReadOnlyCollection<Category>> GetAllLib(Guid id_lib);
        public void DeleteCategory(Guid id);
        public Category TakeCategory(Guid id);
        public Task<Category> UpdateCategory(Guid id, string name);
    }
}
