using FluentValidation;

namespace Bookify.Application.Users;
internal sealed class RegisterUserCommanValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommanValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty();


        RuleFor(x => x.LastName)
            .NotEmpty();


        RuleFor(x => x.Email)
            .EmailAddress()
            .NotEmpty();


        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(5);

    }
}
