using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace SharedLib.Utilities;

public static class HttpClientExtensions
{
    public static async Task<T?> GetResponseWithInterfering<T>(this HttpClient httpClient, string requestUrl, IJSRuntime jsRuntime)
    {
        await jsRuntime.InvokeVoidAsync("alert", $"{nameof(HttpClientExtensions)} is interfering BEFORE sending the request");
        var res = await httpClient.GetFromJsonAsync<T>(requestUrl);
        await jsRuntime.InvokeVoidAsync("alert", $"{nameof(HttpClientExtensions)} is interfering AFTER sending the request");
        return res;
    }
}
