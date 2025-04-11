namespace BuildingBlocks.Models.Exceptions;

/// <summary>
/// Base class for all custom exceptions in the application.
/// </summary>
public abstract class ApplicationException : Exception
{
  /// <summary>
  /// The title describing the error.
  /// </summary>
  public string Title { get; }

  /// <summary>
  /// Constructor with an error message.
  /// </summary>
  /// <param name="title">The title describing the error.</param>
  /// <param name="message">The error message.</param>
  protected ApplicationException(string title,
                                 string message)
    : base(message)
  {
    Title = title;
  }

  /// <summary>
  /// Constructor with an error message and an inner exception.
  /// </summary>
  /// <param name="title">The title describing the error.</param>
  /// <param name="message">The error message.</param>
  /// <param name="innerException">The inner exception.</param>
  protected ApplicationException(string title,
                                 string message,
                                 Exception innerException)
    : base(message, innerException)
  {
    Title = title;
  }
}
