
using FluentValidation.Results;

namespace Ecosia.SearchEngine.Application.Exceptions;

public class ValidationException : ApplicationException
{
    public List<string> ValidationErrors { get; } = new();

    public ValidationException(ValidationResult validationResult)
    {
        foreach (var validationError in validationResult.Errors)
        {
            ValidationErrors.Add(validationError.ErrorMessage);
        }
    }
}