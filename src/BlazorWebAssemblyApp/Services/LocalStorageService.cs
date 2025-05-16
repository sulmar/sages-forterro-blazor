using Microsoft.JSInterop;

namespace BlazorWebAssemblyApp.Services;

public class LocalStorageService(IJSRuntime _js)
{
    public Task SetAsync(string key, string value)  => _js.InvokeVoidAsync("localStorage.setItem", key, value).AsTask();
    public Task<string?> GetAsync(string key) => _js.InvokeAsync<string?>("localStorage.getItem", key).AsTask();
    public Task RemoveAsync(string key) => _js.InvokeVoidAsync("localStorage.removeItem", key).AsTask();

}
