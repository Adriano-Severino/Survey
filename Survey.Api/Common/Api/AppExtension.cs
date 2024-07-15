namespace Survey.Api.Common.Api
{
    /// <summary>
    /// Extensão do Swagger
    /// </summary>
    public static class AppExtension
    {
        /// <summary>
        /// Configuração Swagger embiente de desenvolvimento
        /// </summary>
        /// <param name="app"></param>
        public static void ConfigureDevEnvironment(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

    }
}
