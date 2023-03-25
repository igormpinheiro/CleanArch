namespace Domain.Shared;

public interface IValidationResult
{
    public static readonly Error ValidationError = new("ValidationError", "A validation error occurred.");
    Error[] Errors { get; }
}

public sealed class ValidationResult : Result, IValidationResult
{
    public Error[] Errors { get; }

    public static ValidationResult WithErrors(Error[] errors) => new(errors);

    private ValidationResult(Error[] errors) : base(false, IValidationResult.ValidationError)
    {
        Errors = errors;
    }
}

public sealed class ValidationResult<TValue> : Result<TValue>, IValidationResult
{
    public Error[] Errors { get; }

    public static ValidationResult<TValue> WithErrors(Error[] errors) => new(errors);

    private ValidationResult(Error[] errors) : base(default, false, IValidationResult.ValidationError)
    {
        Errors = errors;
    }
}