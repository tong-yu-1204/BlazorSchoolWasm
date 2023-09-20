using BrowserStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BrowserStorage.Utilities;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<CacheStorageAccessor>();
builder.Services.AddScoped<CookiesStorageAccessor>();
builder.Services.AddScoped<IndexedDbAccessor>();
builder.Services.AddScoped<LocalStorageAccessor>();
builder.Services.AddScoped<MemoryStorageUtility>();
builder.Services.AddScoped<SessionStorageAccessor>();


var host = builder.Build();
using var scope = host.Services.CreateScope();
await using var indexedDb = scope.ServiceProvider.GetService<IndexedDbAccessor>();
if (indexedDb is not null)
{
    await indexedDb.InitializeAsync();
}



await host.RunAsync();
