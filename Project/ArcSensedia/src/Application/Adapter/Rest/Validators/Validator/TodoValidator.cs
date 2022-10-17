using Application.Adapter.Rest.Contract.Request;
using FluentValidation;

namespace Application.Adapter.Rest.Validators.Validator;

public class TodoValidator : AbstractValidator<TodoRequest>
{
    public TodoValidator()
    {
        RuleFor(o => o.Title)
            .NotEmpty()
            .Matches("^[a-zA-Z0-9 ]*$")
            .WithMessage("Nome com problema");

        RuleFor(o => o.Address)
            .NotEmpty();
    }
}
