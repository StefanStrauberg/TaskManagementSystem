namespace TaskService.Application.Helpers;

/// <summary>
/// Represents a set of request parameters for paging, filtering, and sorting data.
/// This class is designed to standardize how queries are made across the application.
/// </summary>
public class RequestParameters
{
  /// <summary>
  /// The maximum allowed page size to prevent excessive data retrieval.
  /// </summary>
  const int maxPageSize = 50;

  /// <summary>
  /// Gets or sets the current page number for paging purposes.
  /// Defaults to 1, representing the first page.
  /// </summary>
  public int PageNumber { get; set; } = 1;

  private int _pageSize = 10;

  /// <summary>
  /// Gets or sets the size of the page, determining how many items are retrieved per page.
  /// </summary>
  public int PageSize 
  { 
      get => _pageSize;
      set 
      {
          _pageSize = (value > maxPageSize) ? maxPageSize : value;
      }
  }

  /// <summary>
  /// Gets or sets the filters to apply to the query.
  /// Example format: "Name==ACME" for filtering by name.
  /// </summary>
  public string? Filters { get; set; }

  /// <summary>
  /// Gets or sets the sorting criteria for the query.
  /// Example format: "Name" (ASC) for ascending order or "Name" (DESC) for descending order.
  /// </summary>
  public string? Sorts { get; set; } 
}
