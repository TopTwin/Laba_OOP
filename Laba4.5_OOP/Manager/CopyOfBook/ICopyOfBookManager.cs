using Laba4._5_OOP.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laba4._5_OOP.Manager.CopyOfBooks
{
     public interface ICopyOfBookManager
    {
        public Task<IReadOnlyCollection<CopyOfBook>> GetAll(Guid id_lib);
    }
}
