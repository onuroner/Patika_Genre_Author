using AutoMapper;
using BookStore.Api.Common;
using BookStore.Api.DbOperations;
using BookStore.Api.Entities;
using System.Linq;

namespace BookStore.Api.Applications.GenreOperations.Queries.GetGenres
{
    public class GetGenresQuery
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetGenresQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<GenresViewModel> Handle()
        {
            var genreList = _dbContext.Genres.OrderBy(x => x.Id).ToList<Genre>();
            List<GenresViewModel> vm = _mapper.Map<List<GenresViewModel>>(genreList); 
            return vm;
        }
    }

    public class GenresViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
