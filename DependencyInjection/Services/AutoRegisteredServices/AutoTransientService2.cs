using DependencyInjection.Services.AutoRegisteredServices.Interfaces;
namespace DependencyInjection.Services.AutoRegisteredServices;

public class AutoTransientService2: ITransientService
{
    public Guid ExampleId { get; set; } = Guid.NewGuid();
}
