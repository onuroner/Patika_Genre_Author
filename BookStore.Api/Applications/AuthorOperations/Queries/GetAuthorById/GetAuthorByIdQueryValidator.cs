using FluentValidation;

namespace BookStore.Api.Applications.AuthorOperations.Queries.GetAuthorById
{
    public class GetAuthorByIdQueryValidator : AbstractValidator<GetAuthorByIdQuery>
    {
        public GetAuthorByIdQueryValidator()
        {
            RuleFor(query => query.AuthorId).NotEmpty().GreaterThan(0);
        }
    }
}
