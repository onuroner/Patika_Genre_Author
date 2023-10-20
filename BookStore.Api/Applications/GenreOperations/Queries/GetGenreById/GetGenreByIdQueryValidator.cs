using FluentValidation;

namespace BookStore.Api.Applications.GenreOperations.Queries.GetGenreById
{
    public class GetGenreByIdQueryValidator : AbstractValidator<GetGenreByIdQuery>
    {
        public GetGenreByIdQueryValidator()
        {
            RuleFor(query => query.GenreId).NotEmpty().GreaterThan(0);
        }
    }
}
