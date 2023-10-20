using AutoMapper;
using BookStore.Api.DbOperations;
using BookStore.Api.Entities;

namespace BookStore.Api.Applications.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorModel Model { get; set; }
        private readonly Context _dbContext;
        private readonly IMapper _mapper;
        public CreateAuthorCommand(Context dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author = _dbContext.Authors.Where(x => x.Name == Model.Name && x.Surname == Model.Surname).SingleOrDefault();

            if (author != null)
            {
                throw new InvalidOperationException("Yazar zaten mevcut.");
            }
            author = _mapper.Map<Author>(Model);

            _dbContext.Authors.Add(author);
            _dbContext.SaveChanges();
        }
    }

    public class CreateAuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }

        public List<Book> Books { get; set; }
    }
}
