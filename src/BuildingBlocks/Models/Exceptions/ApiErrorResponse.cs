namespace BuildingBlocks.Models.Exceptions;

/// <summary>
/// Model representing the JSON response for an error.
/// </summary>
public class ApiErrorResponse(int status,
                              string title,
                              string detail,
                              IReadOnlyDictionary<string, string[]>? errors = null)
{
  /// <summary>
  /// Brief title describing the error.
  /// </summary>
  public string Title { get; } = title;

  /// <summary>
  /// HTTP status code of the error.
  /// </summary>
  public int Status { get; } = status;

  /// <summary>
  /// Detailed description of the error.
  /// </summary>
  public string Detail { get; } = detail;

  /// <summary>
  /// Additional error details (e.g., validation errors).
  /// </summary>
  public IReadOnlyDictionary<string, string[]>? Errors { get; } = errors;
  
  /// <summary>
  /// Creates a generic error response object.
  /// </summary>
  /// <param name="status">HTTP status code.</param>
  /// <param name="message">Error message.</param>
  /// <returns>An ApiErrorResponse object.</returns>
  public static ApiErrorResponse CreateGenericError(int status,
                                                    string message)
  {
    return new ApiErrorResponse(status,
                                "An error occured",
                                message);
  }
}
