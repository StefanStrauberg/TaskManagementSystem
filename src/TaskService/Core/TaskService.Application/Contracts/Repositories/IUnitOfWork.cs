namespace TaskService.Application.Contracts.Repositories;

public interface IUnitOfWork
{
  ITaskEntitiesRepository Repository { get; }
  void Commit();
  Task CommitAsync(CancellationToken cancellationToken);
}
