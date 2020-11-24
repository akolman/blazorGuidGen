using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;

namespace BlazorGuidGenerator
{
    public class Program
    {
        public sealed class ClipboardService
        {
            private readonly IJSRuntime _jsRuntime;

            public ClipboardService(IJSRuntime jsRuntime)
            {
                _jsRuntime = jsRuntime;
            }

            public ValueTask WriteTextAsync(string text)
            {
                return _jsRuntime.InvokeVoidAsync("navigator.clipboard.writeText", text);
            }
        }

        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<ClipboardService>();

            await builder.Build().RunAsync();
        }
    }
}
