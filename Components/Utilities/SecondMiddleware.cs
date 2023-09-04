using Microsoft.JSInterop;

namespace SharedLib.Utilities;

public class SecondMiddleware: DelegatingHandler
{
    private readonly IJSRuntime _jsRuntime;
    public SecondMiddleware(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        await _jsRuntime.InvokeVoidAsync("alert", $"{nameof(SecondMiddleware)} is interfering BEFORE the request");
        var res = await base.SendAsync(request, cancellationToken);
        await _jsRuntime.InvokeVoidAsync("alert", $"{nameof(SecondMiddleware)} is interfering AFTER the request");
        return res;
    }
}
