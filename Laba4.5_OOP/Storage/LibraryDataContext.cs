using Laba_OOP.Storage.Entity;
using Laba4._5_OOP.Storage.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laba_OOP.Storage
{
    public class LibraryDataContext: DbContext
    {
        public LibraryDataContext(DbContextOptions<LibraryDataContext> options) : base(options)
        {

        }

        public DbSet<Reader> Readers { get; set; }
        public DbSet<CopyOfBook> CopyOfBooks { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
