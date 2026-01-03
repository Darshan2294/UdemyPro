using eCommerce.Infrastructure;
using eCommerce.Core;
using eCommerce.API.Middlewares;
using System.Text.Json.Serialization;
using eCommerce.Core.Mappers;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

//Add Infrastructure services
builder.Services.AddInfrastructure();
builder.Services.AddCore();

//Add Controllers to the services collection
builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);


//Build the web application
var app = builder.Build();

app.UseExceptionHandlingMiddleware();

//Routing
app.UseRouting();

//Auth
app.UseAuthentication();
app.UseAuthorization();

//Controller routes
app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
