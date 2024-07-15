using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using MudBlazor.Services;
using Survey.Core;
using Survey.Core.Handlers;
using Survey.Mobile.Handlers;
using System;

namespace Survey.Mobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services
   .AddHttpClient(
       WebConfiguration.HttpClientName,
       opt =>
       {
           opt.BaseAddress = new Uri(Configuration.BackendUrl);
       });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddTransient<ILevantamentoHandler, LevantamentoHandler>();
            builder.Services.AddTransient<IPavimentoHandler, PavimentoHandler>();
            builder.Services.AddTransient<ILuminariaHandler, LuminariaHandler>();
            builder.Services.AddMudServices();

            return builder.Build();
        }
    }
}
