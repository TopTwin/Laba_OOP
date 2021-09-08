using Laba_OOP.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laba4._5_OOP.Storage.Entity;
using Laba4._5_OOP.Storage;

namespace Laba4._5_OOP.Manager.CopyOfBooks
{
    public class CopyOfBookManager : ICopyOfBookManager
    {
        private readonly LibraryDataContext _dbContext;

        public CopyOfBookManager(LibraryDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyCollection<CopyOfBook>> GetAll(Guid id_lib)
        {
            var entitis = await (from CP in _dbContext.CopyOfBooks
                                where CP.Reader.LibraryId == id_lib
                                select CP).
                                Include(cp => cp.Book.category).
                                Include(cp=> cp.Book.author).
                                Include(cp=> cp.Reader.Library).ToListAsync();
       
            return entitis;
        }
    }
}
