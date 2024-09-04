namespace Trainer.Profile.Application.Contracts.Exceptions;

public class ValidationException : ApplicationException
{
    public Dictionary<string, string> Errors { get; set; }

    public ValidationException(Dictionary<string, string> errors)
    {
        Errors = errors;
    }

    public ValidationException(string message, Dictionary<string, string> errors) : base(message)
    {
        Errors = errors;
    }
}