using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Survey.Core;
using Survey.Core.Handlers;
using Survey.Web;
using Survey.Web.Handlers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services
    .AddHttpClient(
        WebConfiguration.HttpClientName,
        opt =>
        {
            opt.BaseAddress = new Uri(Configuration.BackendUrl);
        });

builder.Services.AddTransient<ILevantamentoHandler, LevantamentoHandler>();
builder.Services.AddTransient<IPavimentoHandler, PavimentoHandler>();
builder.Services.AddTransient<ILuminariaHandler, LuminariaHandler>();
builder.Services.AddTransient<IFileDownload, FileDownload>();

await builder.Build().RunAsync();
