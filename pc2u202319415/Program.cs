using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using pc2u202319415.Shared.Infrastructure.Persistence.EFC;
using pc2u202319415.Subscriptions.Application.Internal.CommandServices;
using pc2u202319415.Subscriptions.Domain.Repositories;
using pc2u202319415.Subscriptions.Domain.Services;
using pc2u202319415.Subscriptions.Infrastructure.Persistence.EFC.Repositories;
using pc2u202319415.Shared.Domain.Repositories;
using pc2u202319415.Shared.Infrastructure.Persistence.EFC.Repositories;
using Swashbuckle.AspNetCore.SwaggerUI; // Para SwaggerUI en .NET 9

var builder = WebApplication.CreateBuilder(args);

// 📌 SERVICIOS BASE (OpenAPI built-in + Swagger)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // Genera OpenAPI JSON
builder.Services.AddOpenApi(); // Built-in .NET 9: crea /openapi/v1.json
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Travelers.io Plans API", Version = "v1" });
});

// 📌 REPOS / DI
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPlanRepository, PlanRepository>();
builder.Services.AddScoped<IPlanDomainService, PlanDomainService>();
builder.Services.AddScoped<CreatePlanCommandHandler>();

// 📌 DATABASE: MYSQL (usa tu key "TravelersDbConnection")
var connectionString = builder.Configuration.GetConnectionString("TravelersDbConnection");
if (string.IsNullOrEmpty(connectionString))
    throw new Exception("Database connection string 'TravelersDbConnection' is not set.");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information) // Logs SQL para debug
        .EnableSensitiveDataLogging() // Dev: muestra queries
        .EnableDetailedErrors(); // Dev: errores detallados
});

var app = builder.Build();

// Crea DB/esquema "travelers" si no existe (como PDF)
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated(); // Crea "travelers.plans" con snake_case
}

// 📌 PIPELINE (Swagger UI para .NET 9: orden clave + ruta correcta)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // PRIMERO: Genera /openapi/v1.json (built-in)
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Travelers.io Plans API V1"); // Apunta a built-in JSON (.NET 9)
        options.RoutePrefix = "swagger"; // Accede en /swagger (coincide launchUrl)
    });
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();