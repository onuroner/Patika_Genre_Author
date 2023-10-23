using AutoMapper;

using BookStore.Api.Common;
using BookStore.Api.DbOperations;
using BookStore.Api.Applications.GenreOperations;
using BookStore.Api.Entities;
using BookStore.Api.Applications.GenreOperations.Queries.GetGenres;

namespace BookStore.Api.Applications.GenreOperations.Queries.GetGenreById
{
    public class GetGenreByIdQuery
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int GenreId;
        public GetGenreByIdQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public GenresViewModel Handle()
        {
            var genre = _dbContext.Genres.Where(x => x.Id == GenreId).SingleOrDefault();
            var vm = _mapper.Map<GenresViewModel>(genre);
            return vm;
        }
    }
}
