using Microsoft.JSInterop;

namespace BrowserStorage.Utilities;

public class CacheStorageAccessor: IAsyncDisposable
{
    private Lazy<IJSObjectReference> _accessorJsRef = new();
    private readonly IJSRuntime _runtime;

    public CacheStorageAccessor(IJSRuntime jsRuntime)
    {
        _runtime = jsRuntime;
    }

    public async Task StoreAsync(HttpRequestMessage requestMessage, HttpResponseMessage responseMessage)
    {
        string method = requestMessage.Method.Method;
        string requestBody = await GetRequestBodyAsync(requestMessage);
        string responseBody = await responseMessage.Content.ReadAsStringAsync();
        await waitForReferenceAsync();

        await _accessorJsRef.Value.InvokeVoidAsync("store", requestMessage.RequestUri, method, requestBody, responseBody);

    }
    public async Task<string> GetAsync(HttpRequestMessage requestMessage)
    {
        string method = requestMessage.Method.Method;
        string requestBody = await GetRequestBodyAsync(requestMessage);

        await waitForReferenceAsync();
        return await _accessorJsRef.Value.InvokeAsync<string>("get", requestMessage.RequestUri, method, requestBody);
    }



    public async Task RemoveAsync(HttpRequestMessage requestMessage)
    {
        string method = requestMessage.Method.Method;
        string requestBody = await GetRequestBodyAsync(requestMessage);
        await _accessorJsRef.Value.InvokeVoidAsync("remove", requestMessage.RequestUri, method, requestBody);

    }

    public async Task RemoveAllAsync()
    {
        await _accessorJsRef.Value.InvokeVoidAsync("removeAll");
    }

    public static async Task<string> GetRequestBodyAsync(HttpRequestMessage requestMessage)
    {
        string requestBody = "";
        if(requestMessage.Content is not null)
        {
            requestBody = await requestMessage.Content.ReadAsStringAsync();
        }
        return requestBody;
    }



    public async ValueTask DisposeAsync()
    {
        if(_accessorJsRef.IsValueCreated)
        {
            await _accessorJsRef.Value.DisposeAsync();
        }

    }


    private async Task waitForReferenceAsync()
    {
        if( _accessorJsRef.IsValueCreated is false )
        {
            _accessorJsRef = new(await _runtime.InvokeAsync<IJSObjectReference>("import", "/js/CacheStorageAccessor.js"));
        }
    }
}
