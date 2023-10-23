using AutoMapper;

using BookStore.Api.Common;
using BookStore.Api.DbOperations;
using BookStore.Api.Applications.AuthorOperations;
using BookStore.Api.Entities;
using BookStore.Api.Applications.AuthorOperations.Queries.GetAuthors;

namespace BookStore.Api.Applications.AuthorOperations.Queries.GetAuthorById
{
    public class GetAuthorByIdQuery
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int AuthorId;
        public GetAuthorByIdQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public AuthorsViewModel Handle()
        {
            var Author = _dbContext.Authors.Where(x => x.Id == AuthorId).SingleOrDefault();
            var vm = _mapper.Map<AuthorsViewModel>(Author);
            return vm;
        }
    }
}
