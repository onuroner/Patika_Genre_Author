
using BookStore.Api.DbOperations;

namespace BookStore.Api.Applications.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public UpdateGenreModel Model { get; set; }
        public int GenreId;
        private readonly Context _dbContext;
        public UpdateGenreCommand(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var genre = _dbContext.Genres.Where(x => x.Id == GenreId).SingleOrDefault();

            if (genre is null)
            {
                throw new InvalidOperationException("Kitap bulunamadı.");
            }

            
            
            genre.Name = Model.Name != default ? Model.Name : genre.Name;
            
            genre.IsActive = Model.IsActive != default ? Model.IsActive : genre.IsActive;

            _dbContext.SaveChanges();
        }
    }

    public class UpdateGenreModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
