using Microsoft.EntityFrameworkCore;
using Survey.Api.Data;
using Survey.Api.Handlers;
using Survey.Core;
using Survey.Core.Handlers;
using System.Reflection;

namespace Survey.Api.Common.Api
{
    /// <summary>
    /// Extensão de compilação
    /// </summary>
    public static class BuildExtension
    {
        /// <summary>
        /// Adiciona confiração a api
        /// </summary>
        /// <param name="builder"></param>
        public static void AddConfiguration(this WebApplicationBuilder builder)
        {
            ApiConfiguration.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
            Configuration.BackendUrl = builder.Configuration.GetValue<string>("BackEndUrl") ?? string.Empty;
            Configuration.FrontendUrl = builder.Configuration.GetValue<string>("FrontEndUrl") ?? string.Empty;
            Configuration.MobileName = builder.Configuration.GetValue<string>("MobileName") ?? string.Empty;
        }

        /// <summary>
        /// Adiciona Swagger para documentaçào 
        /// </summary>
        /// <param name="builder"></param>
        public static void AddDocumentation(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(x =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                x.IncludeXmlComments(xmlPath);
            });
        }

        /// <summary>
        /// Adiona o db context do entity framework
        /// </summary>
        /// <param name="builder"></param>
        public static void AddDataContexts(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(
                x => x.UseSqlServer(ApiConfiguration.ConnectionString));
        }

        /// <summary>
        /// Adiciona o cors
        /// </summary>
        /// <param name="builder"></param>
        public static void AddCrossOrigin(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(
                options => options.AddPolicy(
                    ApiConfiguration.CorsPolicyName,
                    policy => policy.WithOrigins([
                        Configuration.BackendUrl,
                    Configuration.FrontendUrl,
                    Configuration.MobileName,
                    ])
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    ));
        }

        /// <summary>
        /// Adciona os serviços da api
        /// </summary>
        /// <param name="builder"></param>
        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<ILevantamentoHandler, LevantamentoHandler>();
            builder.Services.AddTransient<IPavimentoHandler, PavimentoHandler>();
            builder.Services.AddTransient<ILuminariaHandler, LuminariaHandler>();
        }
    }
}
