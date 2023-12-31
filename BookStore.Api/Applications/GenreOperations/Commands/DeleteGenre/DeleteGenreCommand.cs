﻿using BookStore.Api.DbOperations;

namespace BookStore.Api.Applications.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        private readonly IBookStoreDbContext _dbContext;
        public int GenreId;
        public DeleteGenreCommand(IBookStoreDbContext dbContext)
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
            
            _dbContext.Genres.Remove(genre);
            _dbContext.SaveChanges();           
        }
    }
}
