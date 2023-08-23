namespace DependencyInjection.Services.ServiceScopes;

public class SingletonService
{
    public Guid ExampleId { get; set; } = Guid.NewGuid();
}
