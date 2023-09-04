using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MultipleApiInteraction;
using SharedLib.Utilities;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<CustomHttpClient>();
builder.Services.AddHttpClient("First Api", httpClient => httpClient.BaseAddress = new("http://localhost:5056"));
builder.Services.AddHttpClient("Second Api", httpClient => httpClient.BaseAddress = new("http://localhost:5247"));

builder.Services.AddHttpClient<SecondApiHttpClientWrapper>(httpClient => httpClient.BaseAddress = new("http://localhost:5247"));

// Request Interference

builder.Services.AddTransient<FirstMiddleware>();
builder.Services.AddTransient<SecondMiddleware>();
builder.Services
    .AddHttpClient(
        "HttpClientWithMiddlewares",
        httpClient => httpClient.BaseAddress = new("http://localhost:5247")
    )
    .AddHttpMessageHandler<FirstMiddleware>()
    .AddHttpMessageHandler<SecondMiddleware>();

builder.Services
    .AddHttpClient<InterfereWithHttpClientWrapper>(httpClient => httpClient.BaseAddress = new("http://localhost:5247"))
    .AddHttpMessageHandler<FirstMiddleware>()
    .AddHttpMessageHandler<SecondMiddleware>();

builder.Services
    .AddHttpClient("InterfereWithHttpClientExtensions", httpClient => httpClient.BaseAddress = new("http://localhost:5056"))
    .AddHttpMessageHandler<FirstMiddleware>()
    .AddHttpMessageHandler<SecondMiddleware>();
await builder.Build().RunAsync();
