using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Prism.SourceGenerators.Docs;
using Prism.SourceGenerators.Docs.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var httpForLocales = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
builder.Services.AddSingleton(_ => new LocalizationService(httpForLocales, builder.HostEnvironment));
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(sp.GetRequiredService<IWebAssemblyHostEnvironment>().BaseAddress) });
builder.Services.AddMudServices();

await builder.Build().RunAsync();
