﻿using BookStore.Api.DbOperations;
using BookStore.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Tests.Application.TestsSetup
{
    public static class Books
    {
        public static void AddBooks(this Context context)
        {
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
        }
    }
}
