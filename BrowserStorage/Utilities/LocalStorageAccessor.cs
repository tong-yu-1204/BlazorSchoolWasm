using Microsoft.JSInterop;

namespace BrowserStorage.Utilities;

public class LocalStorageAccessor : IAsyncDisposable
{
    private Lazy<IJSObjectReference> _accessorJSRef = new();
    private readonly IJSRuntime _jsRuntime;

    public LocalStorageAccessor(IJSRuntime jSRuntime)
    {
        _jsRuntime = jSRuntime;
    }

    public async Task SetValueAsync<T>(string key, T value)
    {
        await waitForReferenceAsync();
        await _accessorJSRef.Value.InvokeVoidAsync("set", key, value);
    }

    public async Task<T> GetValueAsync<T>(string key)
    {
        await waitForReferenceAsync();
        T result = await _accessorJSRef.Value.InvokeAsync<T>("get", key);

        return result;

    }

    public async Task RemoveValueAsync(string key)
    {
        await waitForReferenceAsync();
        await _accessorJSRef.Value.InvokeVoidAsync("remove", key);
    }


    public async Task ClearAllAsync()
    {
        await waitForReferenceAsync();
        await _accessorJSRef.Value.InvokeVoidAsync("clear");
    }
    private async Task waitForReferenceAsync()
    {
        if (_accessorJSRef.IsValueCreated is false)
        {
            _accessorJSRef =
                new(await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "/js/LocalStorageAccessor.js"));

        }
    }
    public async ValueTask DisposeAsync()
    {
        if (_accessorJSRef.IsValueCreated)
        {
            await _accessorJSRef.Value.DisposeAsync();

        }
    }
}
