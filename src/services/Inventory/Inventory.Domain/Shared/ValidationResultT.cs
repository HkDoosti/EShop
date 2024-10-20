namespace Inventory.Domain.Shared;

public class ValidationResult<TValue> :
    Result<TValue>, IValidationResult
{
    private ValidationResult(Error[] errors) : base(default, false, IValidationResult.ValidationError) =>
        Errors = errors;
    
    public Error[] Errors { get; }

    public static ValidationResult<TValue> WithError(Error[] errors) =>
      new ValidationResult<TValue>(errors);
}
