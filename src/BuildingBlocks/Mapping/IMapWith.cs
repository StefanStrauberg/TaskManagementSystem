namespace BuildingBlocks.Mapping;

/// <summary>
/// Interface to define a mapping configuration for a specific type.
/// Classes implementing this interface specify how to map themselves to another type using Mapster.
/// </summary>
/// <typeparam name="T">The type to map to.</typeparam>
public interface IMapWith<T>
{
  /// <summary>
  /// Defines the mapping configuration using Mapster's TypeAdapterConfig.
  /// This method creates a new mapping configuration between the implementing type and the specified target type.
  /// </summary>
  /// <param name="config">The Mapster configuration object.</param>
  void Mapping(TypeAdapterConfig config)
    => config.NewConfig(GetType(), typeof(T));
}
