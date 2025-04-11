namespace TaskService.Application.Models;

/// <summary>
/// Custom exception for cases where a TaskEntity is not found.
/// </summary>
public class TaskEntityNotFoundException(string message) 
  : NotFoundException(message)
{
}
