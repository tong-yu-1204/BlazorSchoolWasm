using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace SharedLib.Utilities;

public class InterfereWithHttpClientWrapper
{
    private readonly HttpClient _httpClient;
    private readonly IJSRuntime _jsRuntime;
    public InterfereWithHttpClientWrapper(IJSRuntime jsRuntime, HttpClient httpClient)
    {
        _httpClient = httpClient;
        _jsRuntime = jsRuntime;
    }

    public async Task<T?> GetAsync<T>(string requestUrl)
    {
        await _jsRuntime.InvokeVoidAsync("alert", $"{nameof(InterfereWithHttpClientWrapper)} is interfering BEFORE sending the request");
        var res = await _httpClient.GetFromJsonAsync<T>(requestUrl);
        await _jsRuntime.InvokeVoidAsync("alert", $"{nameof(InterfereWithHttpClientWrapper)} is interfering AFTER sending the request");
        return res;
    }
}
