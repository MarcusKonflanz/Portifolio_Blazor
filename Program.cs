using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Portifolio_Blazor;
using Portifolio_Blazor.Services.Language;
using System.ComponentModel.Design;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<ILanguageService, LanguageService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();

var host = builder.Build();

var languageContainer = host.Services.GetRequiredService<ILanguageService>();
languageContainer.SetupChangeLanguage("pt-br");

await host.RunAsync();