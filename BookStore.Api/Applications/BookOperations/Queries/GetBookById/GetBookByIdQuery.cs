﻿using AutoMapper;
using BookStore.Api.Applications.BookOperations.Queries.GetBooks;
using BookStore.Api.Common;
using BookStore.Api.DbOperations;

namespace BookStore.Api.Applications.BookOperations.Queries.GetBookById
{
    public class GetBookByIdQuery
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId;
        public GetBookByIdQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public BooksViewModel Handle()
        {
            var book = _dbContext.Books.Where(x => x.Id == BookId).SingleOrDefault();
            var vm = _mapper.Map<BooksViewModel>(book);
            return vm;
        }
    }
}
