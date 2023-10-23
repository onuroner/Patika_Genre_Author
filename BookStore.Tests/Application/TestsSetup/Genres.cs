using BookStore.Api.DbOperations;
using BookStore.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Tests.Application.TestsSetup
{
    public static class Genres
    {
        public static void AddGenres(this Context context)
        {
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
        }
    }
}
