
using BookStore.Api.DbOperations;
using BookStore.Api.Entities;

namespace BookStore.Api.Applications.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        public UpdateAuthorModel Model { get; set; }
        public int AuthorId;
        private readonly IBookStoreDbContext _dbContext;
        public UpdateAuthorCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var Author = _dbContext.Authors.Where(x => x.Id == AuthorId).SingleOrDefault();

            if (Author is null)
            {
                throw new InvalidOperationException("Yazar bulunamadı.");
            }

            
            
            Author.Name = Model.Name != default ? Model.Name : Author.Name;
            Author.Surname = Model.Surname != default ? Model.Surname : Author.Surname;
            Author.DateOfBirth = Model.DateOfBirth != default ? Model.DateOfBirth : Author.DateOfBirth;
            Author.Books = Model.Books != default ? Model.Books : Author.Books;

            _dbContext.SaveChanges();
        }
    }

    public class UpdateAuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }

        public List<Book> Books { get; set; }
    }
}
