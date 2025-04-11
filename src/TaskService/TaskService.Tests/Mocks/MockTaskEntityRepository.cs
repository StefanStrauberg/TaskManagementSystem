namespace TaskService.Tests.Mocks;

internal class MockTaskEntityRepository
{
  internal static Mock<ITaskEntitiesRepository> GetProductRepository()
  {
    var taskEntities = GetTaskEntities();
    var mockRepo = new Mock<ITaskEntitiesRepository>();

    mockRepo.Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync((CancellationToken cancellationToken) =>
            {
              return taskEntities;
            });

    mockRepo.Setup(x => x.FirstByIdAsync(It.IsAny<Guid>(),
                                         It.IsAny<CancellationToken>()))
            .ReturnsAsync((Guid id,
                           CancellationToken cancellationToken) =>
            {
              return taskEntities.First(x => x.Id == id);
            });

    mockRepo.Setup(x => x.InsertOne(It.IsAny<TaskEntity>()))
            .Callback((TaskEntity entity) =>
            {
              taskEntities.Add(entity);
            });

    mockRepo.Setup(x => x.InsertMany(It.IsAny<IEnumerable<TaskEntity>>()))
            .Callback((IEnumerable<TaskEntity> entities) =>
            {
              taskEntities.AddRange(entities);
            });

    mockRepo.Setup(x => x.ReplaceOne(It.IsAny<TaskEntity>()))
            .Callback((TaskEntity entity) =>
            {
              var toUpdate = taskEntities.First(x => x.Id == entity.Id);
              toUpdate = entity;
            });

    mockRepo.Setup(x => x.ReplaceMany(It.IsAny<IEnumerable<TaskEntity>>()))
            .Callback((IEnumerable<TaskEntity> entities) =>
            {
              foreach (var item in entities)
              {
                var toUpdate = taskEntities.First(x => x.Id == item.Id);
                toUpdate = item;
              }
            });

    mockRepo.Setup(x => x.DeleteOne(It.IsAny<TaskEntity>()))
            .Callback((TaskEntity entity) =>
            {
              var toDelete = taskEntities.First(x => x.Id == entity.Id);
              taskEntities.Remove(toDelete);
            });

    mockRepo.Setup(x => x.DeleteMany(It.IsAny<IEnumerable<TaskEntity>>()))
            .Callback((IEnumerable<TaskEntity> entities) =>
            {
              foreach (var item in entities)
              {
                var toDelete = taskEntities.First(x => x.Id == item.Id);
                taskEntities.Remove(toDelete);
              }
            });

    mockRepo.Setup(x => x.AnyAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync((CancellationToken cancellationToken) =>
            {
              return taskEntities.Count != 0;
            });

    mockRepo.Setup(x => x.AnyByIdAsync(It.IsAny<Guid>(),
                                       It.IsAny<CancellationToken>()))
            .ReturnsAsync((Guid id,
                           CancellationToken cancellationToken) =>
            {
              if (taskEntities.FirstOrDefault(x => x.Id == id) is not null)
                return true;
              else
                return false;
            });

    mockRepo.Setup(x => x.GetCountAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync((CancellationToken cancellationToken) =>
            {
              return taskEntities.Count;
            });

    return mockRepo;
  }

  static List<TaskEntity> GetTaskEntities()
  {
    var path = Directory.GetCurrentDirectory();
    var file = File.ReadAllText(path + "/TaskEntityList.json");
    return JsonConvert.DeserializeObject<List<TaskEntity>>(file)!;
  }
}
