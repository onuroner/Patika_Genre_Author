using AutoMapper;
using BookStore.Api.DbOperations;
using BookStore.Api.Entities;

namespace BookStore.Api.Applications.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        public CreateGenreModel Model { get; set; }
        private readonly Context _dbContext;
        private readonly IMapper _mapper;
        public CreateGenreCommand(Context dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var genre = _dbContext.Genres.Where(x => x.Name == Model.Name).SingleOrDefault();

            if (genre != null)
            {
                throw new InvalidOperationException("Kitap zaten mevcut.");
            }
            genre = _mapper.Map<Genre>(Model);

            _dbContext.Genres.Add(genre);
            _dbContext.SaveChanges();
        }
    }

    public class CreateGenreModel
    {
        public string Name { get; set; }
    }
}
