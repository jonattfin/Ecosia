using FluentValidation;

namespace Ecosia.SearchEngine.Application.Features.Reports.Commands;

public class CreateReportCommandValidator : AbstractValidator<CreateReportCommand>
{
    public CreateReportCommandValidator()
    {
        
    }
}