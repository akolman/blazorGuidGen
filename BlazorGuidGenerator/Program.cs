using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;

namespace BlazorGuidGenerator
{
    public class Program
    {
        public sealed class ClipboardService(IJSRuntime jsRuntime)
        {
            public ValueTask WriteTextAsync(string text)
            {
                return jsRuntime.InvokeVoidAsync("navigator.clipboard.writeText", text);
            }
        }

        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped<ClipboardService>();

            await builder.Build().RunAsync();
        }
    }
}
