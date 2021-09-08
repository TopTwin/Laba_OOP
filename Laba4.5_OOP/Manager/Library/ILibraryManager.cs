using Laba4._5_OOP.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laba4._5_OOP.Manager.Librarys
{
    public interface ILibraryManager
    {
        public Task<IReadOnlyCollection<Library>> GetAll();
        public Task<Library> AddLibrary(string name);
        public void DeleteLibrary(Guid id_delete);
    }
}
