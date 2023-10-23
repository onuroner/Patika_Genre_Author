using AutoMapper;
using BookStore.Api.Applications.BookOperations.Commands.CreateBook;
using BookStore.Api.DbOperations;
using BookStore.Api.Entities;
using BookStore.Tests.Application.TestsSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Tests.Application.BookOperations.Commands.CreateCommand
{
    public class CreateBookCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("Lord of the Rings",0,1)]
        [InlineData("Lord of the Rings", 0, 0)]
        [InlineData("", 100, 1)]
        [InlineData("", 0, 0)]
        [InlineData("Lor", 100, 1)]
        [InlineData("Lord", 1, 0)]
        [InlineData("Lor", 0, 0)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string title, int pageCount,int genreId)
        {
            //arrange
            CreateBookCommand command = new CreateBookCommand(null,null);
            command.Model = new CreateBookModel()
            {
                Title = "",
                PageCount = 0,
                PublishDate = DateTime.Now.Date.AddYears(-1),
                GenreId = 0
            };

            //act
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {
            CreateBookCommand command = new CreateBookCommand(null, null);
            command.Model = new CreateBookModel()
            {
                Title = "Lord of the Rings",
                PageCount = 100,
                PublishDate = DateTime.Now.Date,
                GenreId = 1
            };

            CreateBookCommandValidator validator = new CreateBookCommandValidator();

            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError()
        {
            CreateBookCommand command = new CreateBookCommand(null, null);
            command.Model = new CreateBookModel()
            {
                Title = "Lord of the Rings",
                PageCount = 100,
                PublishDate = DateTime.Now.Date.AddYears(-2),
                GenreId = 1
            };

            CreateBookCommandValidator validator = new CreateBookCommandValidator();

            var result = validator.Validate(command);
            result.Errors.Count.Should().Be(0);
        }
    }
}
