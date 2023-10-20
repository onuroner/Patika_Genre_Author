using FluentValidation;

namespace BookStore.Api.Applications.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator:AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(command => command.Model.Name).MinimumLength(3);
            RuleFor(command => command.Model.Surname).MinimumLength(3);
            

        }
    }
}
