using FluentValidation;

namespace Ecosia.SearchEngine.Application.Features.Projects.Commands;

public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .NotNull()
            .MaximumLength(50);
    }
}