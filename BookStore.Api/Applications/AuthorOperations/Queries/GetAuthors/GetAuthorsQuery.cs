using AutoMapper;
using BookStore.Api.Common;
using BookStore.Api.DbOperations;
using BookStore.Api.Entities;
using System.Linq;

namespace BookStore.Api.Applications.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetAuthorsQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<AuthorsViewModel> Handle()
        {
            var AuthorList = _dbContext.Authors.OrderBy(x => x.Id).ToList<Author>();
            List<AuthorsViewModel> vm = _mapper.Map<List<AuthorsViewModel>>(AuthorList); 
            return vm;
        }
    }

    public class AuthorsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }

        public List<Book> Books { get; set; }
    }
}
