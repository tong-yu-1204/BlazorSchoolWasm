using Microsoft.JSInterop;

namespace BrowserStorage.Utilities;

public class SessionStorageAccessor : IAsyncDisposable
{
    private Lazy<IJSObjectReference> _accessorJsRef = new();
    private readonly IJSRuntime _jsRuntime;
    public SessionStorageAccessor(IJSRuntime jSRuntime)
    {
        _jsRuntime = jSRuntime;
    }

    public async Task SetValueAsync<T>(string key, T value)
    {
        await waitForReferenceAsync();
        await _accessorJsRef.Value.InvokeVoidAsync("set", key, value);
    }

    public async Task<T> GetValueAsync<T>(string key)
    {
        await waitForReferenceAsync();
        var result = await _accessorJsRef.Value.InvokeAsync<T>("get", key);
        return result;
    }

    public async Task RemoveValueAsync(string key)
    {
        await waitForReferenceAsync();
        await _accessorJsRef.Value.InvokeVoidAsync("remove", key);
    }

    public async Task ClearAllAsync()
    {
        await waitForReferenceAsync();
        await _accessorJsRef.Value.InvokeVoidAsync("clear");
    }

    private async Task waitForReferenceAsync()
    {
        if(_accessorJsRef.IsValueCreated is false)
        {
            _accessorJsRef = new(await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "/js/SessionStorageAccessor.js"));

        }

    }
    public async ValueTask DisposeAsync()
    {
        if(_accessorJsRef.IsValueCreated)
        {
            await  _accessorJsRef.Value.DisposeAsync();
        }
    }
}
