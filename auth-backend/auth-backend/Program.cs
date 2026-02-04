using auth_backend.Controllers;
using auth_backend.DAL;
using auth_backend.Helper;
using auth_backend.Models;
using auth_backend.Provider;
using auth_backend.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddJsonFile("appsettings.Local.json", optional: true, reloadOnChange: true);
builder.Configuration.AddEnvironmentVariables();

builder.Services.AddHealthChecks();
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AuthContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AuthConnection"));
});

builder.Services.AddDbContext<MyDocContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDocConnection"));
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

app.Run();
