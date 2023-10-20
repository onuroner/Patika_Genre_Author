﻿using FluentValidation;

namespace BookStore.Api.Applications.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator:AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(command => command.AuthorId).GreaterThan(0);
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.Surname).NotEmpty();
        }
    }
}
