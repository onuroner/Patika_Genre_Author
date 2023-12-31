﻿using BookStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.DbOperations
{
    public class Context:DbContext, IBookStoreDbContext
    {
        public Context(DbContextOptions<Context> options):base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
