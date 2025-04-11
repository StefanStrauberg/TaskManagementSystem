namespace TaskService.Application;

public static class ApplicationServicesRegistration
{
  public static IServiceCollection AddApplicationServices(this IServiceCollection services)
  {
    services.AddMediatR(cfg => 
    {
      cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
    });
    services.AddTransient<ExceptionHandlingMiddleware>();
    return services;
  }
}
