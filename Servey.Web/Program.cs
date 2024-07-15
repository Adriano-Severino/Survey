using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Servey.Web;
using MudBlazor.Services;
using Survey.Api.Handlers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();


//builder.Services
//    .AddHttpClient(
//        WebConfiguration.HttpClientName,
//        opt =>
//        {
//            opt.BaseAddress = new Uri(Configuration.BackendUrl);
//        });

builder.Services.AddTransient<LevantamentoHandler, LevantamentoHandler>();

await builder.Build().RunAsync();
