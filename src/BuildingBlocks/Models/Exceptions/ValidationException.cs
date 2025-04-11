namespace BuildingBlocks.Models.Exceptions;

/// <summary>
/// Exception for validation errors (HTTP 422).
/// Contains a dictionary of validation issues.
/// </summary>
public class ValidationException : ApplicationException
{
  public IReadOnlyDictionary<string, string[]> ErrorDictionary { get; }

  public ValidationException(IReadOnlyDictionary<string, string[]> errorDictionary) 
    : base("Validation Failure", "One or more validation errors occurred")
  {
    if (errorDictionary == null || !errorDictionary.Any())
      throw new ArgumentException("Error dictionary cannot be null or empty.");
    
    ErrorDictionary = errorDictionary;
  }
}
