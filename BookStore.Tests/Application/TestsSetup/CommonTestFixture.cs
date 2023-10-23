using AutoMapper;
using BookStore.Api.Common;
using BookStore.Api.DbOperations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Tests.Application.TestsSetup
{
    public class CommonTestFixture
    {
        public Context Context { get; set; }
        public IMapper Mapper { get; set; }

        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<Context>().UseInMemoryDatabase(databaseName:"BookStoreTestDB").Options;
            Context = new Context(options);
            Context.Database.EnsureCreated();
            Context.AddBooks();
            Context.AddGenres();
            Context.SaveChanges();

            Mapper = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); }).CreateMapper();
        }
    }
}
