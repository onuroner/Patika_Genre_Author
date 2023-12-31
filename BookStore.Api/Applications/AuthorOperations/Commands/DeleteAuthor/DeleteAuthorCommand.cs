﻿using BookStore.Api.DbOperations;

namespace BookStore.Api.Applications.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly IBookStoreDbContext _dbContext;
        public int AuthorId;
        public DeleteAuthorCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var author = _dbContext.Authors.Where(x => x.Id == AuthorId).SingleOrDefault();
            if (author is null)
            {
                throw new InvalidOperationException("Yazar bulunamadı.");
            }
            
            _dbContext.Authors.Remove(author);
            _dbContext.SaveChanges();           
        }
    }
}
