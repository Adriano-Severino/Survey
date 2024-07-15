using Survey.Api;
using Survey.Api.Common.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.AddConfiguration();
//builder.UseSecurity();
builder.AddDataContexts();
builder.AddCrossOrigin();
builder.AddDocumentation();
builder.AddServices();

var app = builder.Build();
if (app.Environment.IsDevelopment())
    app.ConfigureDevEnvironment();

app.UseHttpsRedirection();
app.UseCors(ApiConfiguration.CorsPolicyName);
//app.UseSecurity();
app.UseAuthorization();

app.MapControllers();

app.Run();
