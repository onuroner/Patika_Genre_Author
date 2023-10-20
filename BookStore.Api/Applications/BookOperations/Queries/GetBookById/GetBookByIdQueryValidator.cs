using BookStore.Api.Applications.BookOperations.Queries.GetBookById;
using FluentValidation;

namespace BookStore.Api.Applications.BookOperations.Queries.GetBookById
{
    public class GetBookByIdQueryValidator:AbstractValidator<GetBookByIdQuery>
    {
        public GetBookByIdQueryValidator()
        {
            RuleFor(query => query.BookId).NotEmpty().GreaterThan(0);
        }
    }
}
