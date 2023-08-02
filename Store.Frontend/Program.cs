using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Store.Frontend;
using Store.Repository.Frontend;

using Store.Repository.Service;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<ICharacters, CharactersRespositoryFrontend>();
builder.Services.AddScoped<IClan, ClanRespositoryFrontend>();



builder.Services.AddSweetAlert2();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5288/api/v1/") });

await builder.Build().RunAsync();