using AutoMapper;
using BookStore.Api.Applications.AuthorOperations.Commands.CreateAuthor;
using BookStore.Api.Applications.AuthorOperations.Queries.GetAuthors;
using BookStore.Api.Applications.BookOperations.Commands.CreateBook;

using BookStore.Api.Applications.BookOperations.Queries.GetBooks;
using BookStore.Api.Applications.GenreOperations.Commands.CreateGenre;
using BookStore.Api.Applications.GenreOperations.Queries.GetGenres;
using BookStore.Api.Entities;

namespace BookStore.Api.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));

            CreateMap<CreateGenreModel, Genre>();
            CreateMap<Genre, GenresViewModel>();

            CreateMap<CreateAuthorModel, Author>();
            CreateMap<Author, AuthorsViewModel>();
        }
    }
}
