﻿using BookStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Context(serviceProvider.GetRequiredService<DbContextOptions<Context>>()))
            {
                if (context.Books.Any())
                {
                    return;

                }
                context.Books.AddRange(
                    new Book
                    {
                        //Id = 1,
                        Title = "Lean Startup",
                        GenreId = 1,
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 06, 12)
                    },
                new Book
                {
                    //Id = 2,
                    Title = "Herland",
                    GenreId = 2,
                    PageCount = 250,
                    PublishDate = new DateTime(2010, 05, 23)
                },
                new Book
                {
                    //Id = 3,
                    Title = "Dune",
                    GenreId = 2,
                    PageCount = 540,
                    PublishDate = new DateTime(2001, 02, 21)
                }
                );

                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Personal Growth",
                    },
                    new Genre
                    {
                        Name = "Sciemce Fiction",
                    },
                    new Genre
                    {
                        Name = "Romance",
                    }
                );
                context.SaveChanges();

                context.Authors.AddRange(
                    new Author
                    {
                        
                        Name = "Eric",
                        Surname = "Ries",
                        DateOfBirth = new DateTime(1978,12,2),
                        Books = new List<Book>
                        {
                            context.Books.FirstOrDefault(x => x.Id == 1)
                        }

                    },
                    new Author
                    {
                       
                        Name = "Frank",
                        Surname = "Herbert",
                        DateOfBirth = new DateTime(1968, 4, 23),
                        Books = new List<Book>
                        {
                            context.Books.FirstOrDefault(x => x.Id == 2)
                        }
                    },
                    new Author
                    {

                       
                        Name = "Charlotte Perkins",
                        Surname = "Gilman",
                        DateOfBirth = new DateTime(1860, 7, 3),
                        Books = new List<Book>
                        {
                            context.Books.FirstOrDefault(x => x.Id == 3)
                        }
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
