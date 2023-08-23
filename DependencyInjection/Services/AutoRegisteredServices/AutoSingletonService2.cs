using DependencyInjection.Services.AutoRegisteredServices.Interfaces;
namespace DependencyInjection.Services.AutoRegisteredServices;

public class AutoSingletonService2: ISingletonService
{
    public Guid ExampleId { get; set; } = Guid.NewGuid();   
}
