namespace TaskService.Application.Middleware;

/// <summary>
/// Middleware for global exception handling.
/// Logs exceptions and returns a unified JSON response to the client.
/// </summary>
public class ExceptionHandlingMiddleware(IAppLogger<ExceptionHandlingMiddleware> logger)
  : IMiddleware
{
  // Cache JsonSerializerOptions as a static readonly field
  private static readonly JsonSerializerOptions _jsonOptions = new()
  {
      PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
      WriteIndented = false
  };

  /// <summary>
  /// Main method for processing incoming HTTP requests.
  /// </summary>
  /// <param name="context">The HTTP context of the current request.</param>
  /// <param name="next">Delegate to pass control to the next middleware.</param>
  public async Task InvokeAsync(HttpContext context,
                                RequestDelegate next)
  {
    try
    {
      await next(context);
    }
    catch (Exception ex)
    {
      var sb = new StringBuilder();
      sb.Append($"Exception: {ex.GetType().Name}, ");
      sb.Append($"Message: {ex.Message}, ");
      sb.Append($"StackTrace: {ex.StackTrace}");
      logger.LogError(sb.ToString());
      await HandleExceptionAsync(context, ex);
    }
  }

  /// <summary>
  /// Generates a unified JSON response based on the exception type.
  /// </summary>
  /// <param name="context">The HTTP context of the current request.</param>
  /// <param name="ex">The exception to be handled.</param>
  static async Task HandleExceptionAsync(HttpContext context,
                                         Exception ex)
  {
    var statusCode = GetStatusCode(ex);
    var response = new ApiErrorResponse(status: statusCode,
                                        title: GetTitle(ex),
                                        detail: ex.Message,
                                        errors: GetErrors(ex));
    context.Response.ContentType = "application/json";
    context.Response.StatusCode = statusCode;
    
    await context.Response
                 .WriteAsync(JsonSerializer.Serialize(response,
                                                      _jsonOptions));
  }

  /// <summary>
  /// Returns the appropriate HTTP status code based on the exception type.
  /// </summary>
  /// <param name="ex">The exception to analyze.</param>
  /// <returns>The HTTP status code.</returns>
  static int GetStatusCode(Exception ex) =>
    ex switch
    {
      BadRequestException => StatusCodes.Status400BadRequest,
      NotFoundException => StatusCodes.Status404NotFound,
      ValidationException => StatusCodes.Status422UnprocessableEntity,
      _ => StatusCodes.Status500InternalServerError
    };

  /// <summary>
  /// Returns the error title based on the exception type.
  /// </summary>
  /// <param name="ex">The exception to analyze.</param>
  /// <returns>The error title.</returns>
  static string GetTitle(Exception ex) =>
    ex switch
    {
      ApplicationException applicationException => applicationException.Title,
      _ => "Server Error"
    };

  /// <summary>
  /// Extracts additional error details (e.g., for validation exceptions).
  /// </summary>
  /// <param name="ex">The exception to analyze.</param>
  /// <returns>A dictionary of errors or null if no additional details are available.</returns>
  static IReadOnlyDictionary<string, string[]>? GetErrors(Exception ex)
  {
    IReadOnlyDictionary<string, string[]> errors = default!;

    if (ex is ValidationException validationException)
      errors = validationException.ErrorDictionary;

    return errors;
  }
}
