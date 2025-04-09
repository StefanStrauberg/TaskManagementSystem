namespace TaskService.Application.Contracts.Logger;

/// <summary>
/// Interface for an application-wide logger that supports logging information, warnings, and errors.
/// The generic type parameter <typeparamref name="T"/> allows the logger to associate logs 
/// with a specific class or context.
/// </summary>
public interface IAppLogger<T>
{
  /// <summary>
  /// Logs an informational message, useful for tracking general application flow or state.
  /// </summary>
  /// <param name="message">The message to log.</param>
  /// <param name="args">Optional parameters for formatting the message.</param>
  void LogInformation(string message, params object[] args);

  /// <summary>
  /// Logs a warning message, typically used to highlight potential issues or unexpected behavior 
  /// that does not interrupt application execution.
  /// </summary>
  /// <param name="message">The message to log.</param>
  /// <param name="args">Optional parameters for formatting the message.</param>
  void LogWarning(string message, params object[] args);

  /// <summary>
  /// Logs an error message, generally for reporting failures, exceptions, or critical issues.
  /// </summary>
  /// <param name="message">The message to log.</param>
  /// <param name="args">Optional parameters for formatting the message.</param>
  void LogError(string message, params object[] args);
}
