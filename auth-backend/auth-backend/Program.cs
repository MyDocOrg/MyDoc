using auth_backend.Controllers;
using auth_backend.DAL;
using auth_backend.DTO.Contants;
using auth_backend.Helper;
using auth_backend.Middleware;
using auth_backend.Models;
using auth_backend.Provider;
using auth_backend.Services;
using DotNetEnv;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// Cargar variables de entorno desde el archivo .env en la raíz del workspace
var envPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", ".env");
if (File.Exists(envPath))
{
    Env.Load(envPath);
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddJsonFile("appsettings.Local.json", optional: true, reloadOnChange: true);
builder.Configuration.AddEnvironmentVariables();

// Configurar JWT desde variables de entorno
builder.Configuration["Jwt:Key"] = Environment.GetEnvironmentVariable("JWT_KEY") 
    ?? builder.Configuration["Jwt:Key"];
builder.Configuration["Jwt:Issuer"] = Environment.GetEnvironmentVariable("JWT_ISSUER") 
    ?? builder.Configuration["Jwt:Issuer"];
builder.Configuration["Jwt:Audience"] = Environment.GetEnvironmentVariable("JWT_AUDIENCE") 
    ?? builder.Configuration["Jwt:Audience"];
builder.Configuration["Jwt:ExpiresMinutes"] = Environment.GetEnvironmentVariable("JWT_EXPIRESMINUTES") 
    ?? builder.Configuration["Jwt:ExpiresMinutes"] 
    ?? "1440";
    
builder.Services.AddHealthChecks();
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        // Personalizar respuesta de errores de validación
        options.InvalidModelStateResponseFactory = context =>
        {
            var errors = context.ModelState
                .Where(e => e.Value?.Errors.Count > 0)
                .Select(e => new
                {
                    Field = e.Key,
                    Messages = e.Value?.Errors.Select(x => x.ErrorMessage).ToArray()
                })
                .ToList();

            var firstError = errors.FirstOrDefault()?.Messages?.FirstOrDefault() ?? "Errores de validación";
            var response = ApiResponse<object>.Fail(
                message: firstError,
                status: 400,
                data: errors
            );

            return new BadRequestObjectResult(response)
            {
                StatusCode = 400
            };
        };
    });
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(c =>
    c.OperationFilter<ApplicationHeaderOperationFilter>()
);
builder.Services.AddDbContext<AuthContext>(options =>
{
    var connectionString = Environment.GetEnvironmentVariable("AUTH_CONN") 
        ?? builder.Configuration.GetConnectionString("AuthConnection");
    options.UseSqlServer(connectionString);
});

builder.Services.AddDbContext<MyDocContext>(options =>
{
    var connectionString = Environment.GetEnvironmentVariable("MYDOC_CONN") 
        ?? builder.Configuration.GetConnectionString("MyDocConnection");
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<AuthDAL>();
builder.Services.AddScoped<ApplicationDAL>();
builder.Services.AddScoped<RoleDAL>();
builder.Services.AddScoped<MyDocDAL>();
builder.Services.AddScoped<MyVetDAL>();
builder.Services.AddScoped<SuscriptionDAL>();

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<ApplicationService>();
builder.Services.AddScoped<RoleService>();
builder.Services.AddScoped<SuscriptionService>();

builder.Services.AddScoped<JwtHelper>();
builder.Services.AddScoped<ApplicationProvider>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultCors", policy =>
    {
        policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();   
    });
});

var app = builder.Build();

// Middleware de manejo de errores (debe ir primero)
app.UseMiddleware<ErrorHandlerMiddleware>();

// Configure the HTTP request pipeline.
// Swagger habilitado para producción (proyecto educativo)
app.MapOpenApi();
app.UseSwagger();
app.UseSwaggerUI();

// if (!builder.Configuration.GetValue<bool>("DisableHttpsRedirect"))
// {
//     app.UseHttpsRedirection();
// }

app.UseCors("DefaultCors");

app.UseAuthorization();

app.MapControllers();
app.MapHealthChecks("/health").AllowAnonymous();

app.MapGet("/", () => Results.Ok("Auth API running"));
app.Run();
