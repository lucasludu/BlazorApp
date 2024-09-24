using BlazorAppVisualStudio;
using BlazorAppVisualStudio.Services;
using BlazorAppVisualStudio.Services.Interfaces;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");




var apiUrl = builder.Configuration.GetValue<string>("apiUrl");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiUrl) });

builder.Services.AddScoped< ICategoryServices, CategoryServices>();
builder.Services.AddScoped< IProductServices, ProductServices>();

builder.Services.AddBlazoredToast();

await builder.Build().RunAsync();
