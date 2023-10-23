using BookStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.DbOperations
{
    public interface IBookStoreDbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }

        int SaveChanges();
    }
}
