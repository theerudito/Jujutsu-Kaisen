using CurrieTechnologies.Razor.SweetAlert2;
using JujutsuKaisen.Frontend;
using JujutsuKaisen.Helpers;
using JujutsuKaisen.Repository.Frontend;
using JujutsuKaisen.Repository.Service;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped<ICharacters, CharactersRespositoryFrontend>();
builder.Services.AddScoped<IClan, ClanRespositoryFrontend>();

builder.Services.AddAutoMapper(typeof(MapperConfiguration));


builder.Services.AddSweetAlert2();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5288/api/v1/") });

await builder.Build().RunAsync();
