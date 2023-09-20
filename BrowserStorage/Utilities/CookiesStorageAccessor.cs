using Microsoft.JSInterop;

namespace BrowserStorage.Utilities;

public class CookiesStorageAccessor: IAsyncDisposable
{
    private Lazy<IJSObjectReference> _accessorJsRef = new();
    private readonly IJSRuntime _runtime;


    public CookiesStorageAccessor(IJSRuntime jSRuntime)
    {
        _runtime = jSRuntime;
    }


    public async Task<T> GetValueAsync<T>(string key)
    {
        await waitForReferenceAsync();
        T result = await _accessorJsRef.Value.InvokeAsync<T>("get", key);
        return result;
    }

    public async Task SetValueAsync<T>(string key, T value)
    {
        await waitForReferenceAsync();
        await _accessorJsRef.Value.InvokeVoidAsync("set", key, value);

    }

    private async Task waitForReferenceAsync()
    {
        if(_accessorJsRef.IsValueCreated is false)
        {
            _accessorJsRef = new(await _runtime.InvokeAsync<IJSObjectReference>("import", "/js/CookiesStorageAccessor.js"));
        }

    }
    public async ValueTask DisposeAsync()
    {
        if(_accessorJsRef.IsValueCreated)
        {
            await _accessorJsRef.Value.DisposeAsync();
        }
    }

}
