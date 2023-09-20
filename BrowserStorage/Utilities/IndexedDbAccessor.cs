using Microsoft.JSInterop;

namespace BrowserStorage.Utilities;

public class IndexedDbAccessor : IAsyncDisposable
{
    private Lazy<IJSObjectReference> _accessorJsRef = new();
    private readonly IJSRuntime _jsRuntime;
    public IndexedDbAccessor(IJSRuntime jSRuntime)
    {
        _jsRuntime = jSRuntime;
    }

    public async Task InitializeAsync()
    {
        await waitForReferenceAsync();
        await _accessorJsRef.Value.InvokeVoidAsync("initialize");
    }
    public async Task<T> GetValueAsync<T>(string collectionName, int bookId)
    {
        await waitForReferenceAsync();
        return await _accessorJsRef.Value.InvokeAsync<T>("get", collectionName, bookId);
    }

    public async Task SetValueAsync<T>(string collectionName, T value)
    {
        await waitForReferenceAsync();
        await _accessorJsRef.Value.InvokeVoidAsync("set", collectionName, value);
    }



    private async Task waitForReferenceAsync()
    {
        if (_accessorJsRef.IsValueCreated is false)
        {
            _accessorJsRef = new(await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "/js/IndexedDbAccessor.js"));
        }

    }
    public async ValueTask DisposeAsync()
    {
        if (_accessorJsRef.IsValueCreated)
        {
            await _accessorJsRef.Value.DisposeAsync();
        }
    }
}
