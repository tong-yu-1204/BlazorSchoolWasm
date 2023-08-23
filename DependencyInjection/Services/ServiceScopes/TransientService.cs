namespace DependencyInjection.Services.ServiceScopes;

public class TransientService
{
    public Guid ExampleId { get; set; } = Guid.NewGuid();
}
