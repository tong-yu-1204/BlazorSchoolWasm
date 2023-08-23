namespace DependencyInjection.Services;

public class ServiceWithParameter
{
    public string ExampleString { get; set; } = "VALUE from ServiceWithParameter: Blazor School";
    public ServiceWithParameter(string exampleString)
    {
        ExampleString = exampleString;
    }
}
