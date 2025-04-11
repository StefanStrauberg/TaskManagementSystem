namespace BuildingBlocks.Mapping;

/// <summary>
/// Centralized class to apply all mapping configurations from a specific assembly.
/// It dynamically discovers and applies mapping rules for types implementing IMapWith<>.
/// </summary>
public sealed class AssemblyMappingConfig
{
  /// <summary>
  /// Constructor that initializes the mapping process for the provided assembly.
  /// </summary>
  /// <param name="assembly">The assembly to scan for mapping configurations.</param>
  public AssemblyMappingConfig(Assembly assembly)
    => ApplyMappingFromAssembly(assembly);

  /// <summary>
  /// Scans the specified assembly for types implementing IMapWith<> and applies their mapping configurations.
  /// </summary>
  /// <param name="assembly">The assembly to scan for mapping configurations.</param>
  void ApplyMappingFromAssembly(Assembly assembly)
  {
    var types = assembly.GetExportedTypes()
                        .Where(type => type.GetInterfaces()
                                           .Any(x => x.IsGenericType &&
                                                x.GetGenericTypeDefinition() == typeof(IMapWith<>)))
                        .ToList();
                        
    foreach (var type in types)
    {
      var instance = Activator.CreateInstance(type);
      var mappingMethodName = nameof(IMapWith<object>.Mapping);
      var interfaceMethod = type.GetInterfaces()
                                .FirstOrDefault(x => x.IsGenericType &&
                                                     x.GetGenericTypeDefinition() == typeof(IMapWith<>))
                                ?.GetMethod(mappingMethodName);
      interfaceMethod?.Invoke(instance, [this]);
    }
  }
}
