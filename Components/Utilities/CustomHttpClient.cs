namespace SharedLib.Utilities;

public class CustomHttpClient: HttpClient
{
    public CustomHttpClient()
    {
        BaseAddress = new("http://localhost:5056");
    }
}
