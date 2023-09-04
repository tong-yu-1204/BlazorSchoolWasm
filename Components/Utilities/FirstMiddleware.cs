using Microsoft.JSInterop;

namespace SharedLib.Utilities;

public class FirstMiddleware : DelegatingHandler
{
    private readonly IJSRuntime _jsRuntime;
    public FirstMiddleware(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        await _jsRuntime.InvokeVoidAsync("alert", $"{nameof(FirstMiddleware)} is interfering BEFORE sending the request");
        var response = await base.SendAsync(request, cancellationToken);
        await _jsRuntime.InvokeVoidAsync("alert", $"{nameof(FirstMiddleware)} is interfering AFTER sending the request");
        return response;
    }
}
