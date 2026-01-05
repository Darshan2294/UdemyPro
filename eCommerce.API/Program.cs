using eCommerce.Infrastructure;
using eCommerce.Core;
using eCommerce.API.Middlewares;
using System.Text.Json.Serialization;
using eCommerce.Core.Mappers;
using AutoMapper;
using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add Infrastructure & Core services
builder.Services.AddInfrastructure();
builder.Services.AddCore();

// Add Controllers
builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Register AutoMapper (scan assembly for profiles)
builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);

// Register your services explicitly if needed
builder.Services.AddScoped<IUserServices, UserService>();

var app = builder.Build();

// Middleware
app.UseExceptionHandlingMiddleware();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// Routes
app.MapControllers();
app.MapGet("/", () => "Hello World!");

app.Run();
