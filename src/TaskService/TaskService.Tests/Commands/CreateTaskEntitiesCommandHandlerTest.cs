namespace TaskService.Tests.Commands;

public class CreateTaskEntitiesCommandHandlerTest()
{
    readonly Mock<ITaskEntitiesRepository> _mockRepo;
    readonly CreateTaskEntityDTO _model;
    readonly CreateTaskEntitiesCommand _command;
    readonly CreateTaskEntitiesCommandHandler _handler;

    public CreateTaskEntitiesCommandHandlerTest()
    {
      _mockRepo = MockTaskEntityRepository.GetProductRepository();
      _model = GetDto();
      _command = new CreateTaskEntitiesCommand(_model);
    }

    [Fact]
    public async Task Check_With_Valid_Model()
    {           
        // Act
        var result = await ((ICommandHandler<CreateTaskEntitiesCommand>)_handler).Handle(_command, default);
        
        // Assert
        result.ShouldBeOfType<Unit>();
    }

    static CreateTaskEntityDTO GetDto()
    {
      var path = Directory.GetCurrentDirectory();
      var json = File.ReadAllText(path + "/TaskEntityList.json");
      var model = JsonConvert.DeserializeObject<CreateTaskEntityDTO>(json)!;
      return model;
    }
}
