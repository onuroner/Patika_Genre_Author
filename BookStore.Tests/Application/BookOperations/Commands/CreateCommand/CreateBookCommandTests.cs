using AutoMapper;
using BookStore.Api.Applications.BookOperations.Commands.CreateBook;
using BookStore.Api.DbOperations;
using BookStore.Api.Entities;
using BookStore.Tests.Application.TestsSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Tests.Application.BookOperations.Commands.CreateCommand
{
    public class CreateBookCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public CreateBookCommandTests(CommonTestFixture testFixture)
        {
            this.context = testFixture.Context;
            this.mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //Hazırlık
            var book = new Book() { Title = "Test_WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn",PageCount=100,PublishDate=new System.DateTime(1990,12,1),GenreId=1 };
            context.Books.Add(book);
            context.SaveChanges();

            CreateBookCommand command = new CreateBookCommand(context, mapper);
            command.Model = new CreateBookModel()
            {
                Title = book.Title
            };
            //Çalıştırma - Doğrulama
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap zaten mevcut.");
            
        }

        [Fact]
        public void WhenValidInputAreGiven_Book_ShouldBeCreated()
        {
            //Hazırlık

            CreateBookCommand command = new CreateBookCommand(context, mapper);
            command.Model = new CreateBookModel()
            {
                Title = "Hobbit",
                PageCount=1000,
                PublishDate=DateTime.Now.Date.AddYears(-10),
                GenreId=1
            };
            //Çalıştırma
            FluentActions
                .Invoking(() => command.Handle()).Invoke();
            //Doğrulama
            var book = context.Books.SingleOrDefault(book => book.Title == "Hobbit");
            book.Should().NotBeNull();
            book.PageCount.Should().Be(1000);
            book.PublishDate.Should().Be(DateTime.Now.Date.AddYears(-10));
            book.Title.Should().Be("Hobbit");
            book.GenreId.Should().Be(1);
        }
    }
}
